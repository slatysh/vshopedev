using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vshope.Application.Util.Abstr;
using Vshope.Common;
using Vshope.Common.Properties;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Vshope.Application.Util
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly string _devEmail;

        private readonly bool _disabled;
        private readonly bool _isDev;

        public EmailService(IConfiguration config)
        {
            _config = config;
            _disabled = bool.Parse(_config["Sendgrid:Disabled"]);
            _devEmail = _config["AppSettings:DevEmail"];
            _isDev = bool.Parse(_config["AppSettings:IsDev"]);
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            if (!_disabled)
            {
                email = _isDev ? _devEmail : email;
                return Execute(_config["Sendgrid:Key"], subject, message, email);
            }

            return Task.CompletedTask;
        }

        public Task SendEmailAsync(string email, EmailTemplateEnum mailType, Dictionary<string, string> paramsDict)
        {
            if (!_disabled)
            {
                email = _isDev ? _devEmail : email;
                var message = EmailTemplateHelper.ReadTemplate(mailType);
                var subject = EmailTemplateHelper.ReadSubject(mailType);
                var attachment = EmailTemplateHelper.ReadAttachment(mailType);
                foreach (var param in paramsDict)
                {
                    message = message.Replace("{{" + param.Key + "}}", param.Value);
                    subject = subject.Replace("{{" + param.Key + "}}", param.Value);
                }
                //todo Remove this crutch
                if (_isDev)
                {
                    message = message.Replace("http://localhost:8080/img/vshopelogosmall.png",
                        "https://freshopdev.azurewebsites.net/img/vshopelogosmall.png");
                }
                return Execute(_config["Sendgrid:Key"], subject, message, email, attachment);
            }

            return Task.CompletedTask;
        }

        private Task Execute(string apiKey, string subject, string message, string email, byte[] attachment = null)
        {
            if (!_disabled)
            {
                email = _isDev ? _devEmail : email;
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage
                {
                    // should be a domain other than yahoo.com, outlook.com, hotmail.com, gmail.com
                    From = new EmailAddress(_config["Sendgrid:FromEmail"], _config["Sendgrid:FromName"]),
                    Subject = subject,
                    HtmlContent = message
                };
                if (attachment != null)
                {
                    var curAttachment = new Attachment()
                    {
                        Content = Convert.ToBase64String(attachment),
                        Type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                        Filename = "Attachment"
                    };
                    msg.Attachments=new List<Attachment>(){curAttachment};
                }
                msg.AddTo(new EmailAddress(email));
                return client.SendEmailAsync(msg);
            }

            return Task.CompletedTask;
        }
    }
}
