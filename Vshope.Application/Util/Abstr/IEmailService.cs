using System.Collections.Generic;
using System.Threading.Tasks;
using Vshope.Common;

namespace Vshope.Application.Util.Abstr
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(string email, EmailTemplateEnum mailType, Dictionary<string, string> paramsDict);
    }
}
