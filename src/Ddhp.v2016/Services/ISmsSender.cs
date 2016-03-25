using System.Threading.Tasks;

namespace Ddhp.v2016.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
