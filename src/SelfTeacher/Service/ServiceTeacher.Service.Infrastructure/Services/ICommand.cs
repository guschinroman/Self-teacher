using SelfTeacher.Service.Infrastructure.Service;

namespace ServiceTeacher.Service.Infrastructure.Services
{
    /// <summary>
    /// Interface for wep api command
    /// </summary>
    public interface ICommand
    {
        CommandResults Execute();
    }

    /// <summary>
    /// Interface for web api with returned data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommand<T>
    {
        CommandResults<T> Execute();
    }
}
