using System.Threading.Tasks;

namespace ServiceTeacher.Service.Domain.Services.EmailService
{
    public interface IClientEmailSender
    {
        Task SendConfirmRegistrationEmail(string email, string name, string code);
    }
}
