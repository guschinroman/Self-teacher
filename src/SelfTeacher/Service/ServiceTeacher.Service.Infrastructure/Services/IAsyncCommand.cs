using SelfTeacher.Service.Infrastructure.Service;
using System.Threading.Tasks;

namespace ServiceTeacher.Service.Infrastructure.Services
{
    public interface IAsyncCommand
    {
        Task<ICommandCommonResults> Execute();
    }

    public interface IAsyncCommand<T>
    {
        Task<ICommandDataResults<T>> Execute();
    }
}
