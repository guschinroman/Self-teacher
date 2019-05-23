using ServiceTeacher.Service.Domain.Entities;
using System.Threading.Tasks;

namespace ServiceTeacher.Service.Domain.Services.AuthSerivce
{
    public interface IVkAuthService
    {
        Task<User> GetAndSaveUser(string code);
    }
}
