using System.Collections.Generic;
using System.Net.Mail;
using Vshope.Common.Properties;

namespace Vshope.Common
{
    public static class EmailTemplateHelper
    {
        public static string ReadSubject(EmailTemplateEnum mailType)
        {
            switch (mailType)
            {
                case EmailTemplateEnum.UserRegistrationConfirmedEmail:
                    return Resources.UserRegistrationConfirmedSubject;
                case EmailTemplateEnum.UserRegistrationCreatedEmail:
                    return Resources.UserRegistrationCreatedSubject;
            }

            return null;
        }

        public static string ReadTemplate(EmailTemplateEnum mailType)
        {
            switch (mailType)
            {
                case EmailTemplateEnum.UserRegistrationConfirmedEmail:
                    return Resources.UserRegistrationConfirmedEmail;
                case EmailTemplateEnum.UserRegistrationCreatedEmail:
                    return Resources.UserRegistrationCreatedEmail;
            }

            return null;
        }

        public static byte[] ReadAttachment(EmailTemplateEnum mailType)
        {
            switch (mailType)
            {
                case EmailTemplateEnum.UserRegistrationConfirmedEmail:
                    return null;
                case EmailTemplateEnum.UserRegistrationCreatedEmail:
                    return null;
            }

            return null;
        }
    }
}
