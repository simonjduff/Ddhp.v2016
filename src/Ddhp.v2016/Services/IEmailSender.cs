using System.Threading.Tasks;

namespace Ddhp.v2016.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
