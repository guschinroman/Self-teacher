using System.Threading.Tasks;

namespace ServiceTeacher.Service.Domain.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
