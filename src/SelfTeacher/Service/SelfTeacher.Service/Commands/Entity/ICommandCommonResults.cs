using SelfTeacher.Service.Controllers;
using System;

namespace SelfTeacher.Service.Commands.Entity
{
    public interface ICommandCommonResults
    {
        Exception Exception { get; set; }

        ECommandResults Result { get; set; }

        string Message { get; set; }
    }

    public interface ICommandDataResults<T>: ICommandCommonResults
    {
        T Data { get; set; }
    }

    public class CommandResults: ICommandCommonResults
    {
        public ECommandResults Result { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
