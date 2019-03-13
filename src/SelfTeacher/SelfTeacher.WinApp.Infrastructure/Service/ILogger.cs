using System;

namespace SelfTeacher.WinApp.Infrastructure.Service
{
    public interface ILogger
    {
        void Debug(Exception exception, string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);
        void Fatal(Exception exception, string format, params object[] args);
        void Info(Exception exception, string format, params object[] args);
        void Trace(Exception exception, string format, params object[] args);
        void Warn(Exception exception, string format, params object[] args);

        void Debug(Exception exception);
        void Error(Exception exception);
        void Fatal(Exception exception);
        void Info(Exception exception);
        void Trace(Exception exception);
        void Warn(Exception exception);

        void Debug(string format, params object[] args);
        void Error(string format, params object[] args);
        void Fatal(string format, params object[] args);
        void Info(string format, params object[] args);
        void Trace(string format, params object[] args);
        void Warn(string format, params object[] args);

        void Flush();

        string LogFilePath();
    }
}
