using SelfTeacher.Service.Domain.Entities.Enum;
using System;

namespace SelfTeacher.Service.Infrastructure.Service
{
    /// <summary>
    /// Interface for present returned value from web api command
    /// </summary>
    public interface ICommandCommonResults
    {
        Exception Exception { get; set; }

        ECommandResults Result { get; set; }

        string Message { get; set; }
    }

    /// <summary>
    /// Interface for present returned value from web api command
    /// </summary>
    /// <typeparam name="T">Data from command</typeparam>
    public interface ICommandDataResults<T>: ICommandCommonResults
    {
        T Data { get; set; }
    }

    /// <summary>
    /// Implementation for present returned value from web api command
    /// </summary>
    public class CommandResults: ICommandCommonResults
    {
        public ECommandResults Result { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }

    /// <summary>
    /// Implementation for present returned value from web api command
    /// </summary>
    /// <typeparam name="T">Data from command</typeparam>
    public class CommandResults<T>: ICommandDataResults<T>
    {
        public ECommandResults Result { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public T Data { get; set; }
    }
}
