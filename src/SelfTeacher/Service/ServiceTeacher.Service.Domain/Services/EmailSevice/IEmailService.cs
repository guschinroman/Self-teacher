using System.Threading.Tasks;

namespace ServiceTeacher.Service.Domain.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
