using Bloodonor.Models;

namespace Bloodonor.Interface
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest, string body);
    }
}
