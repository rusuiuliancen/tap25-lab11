using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest request);
    }
}
