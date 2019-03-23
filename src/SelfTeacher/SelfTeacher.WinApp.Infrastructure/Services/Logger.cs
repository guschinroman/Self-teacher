using NLog;
using NLog.Targets;
using SelfTeacher.WinApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SelfTeacher.WinApp.Infrastructure.Services
{
    public class Logger : SelfTeacher.WinApp.Domain.Services.ILogger
    {
        private readonly NLog.Logger _logger;

        public Logger(string logConfiguration)
        {
            _logger = LogManager.GetLogger(logConfiguration);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            if (_logger.IsDebugEnabled)
            {
                var logEvent = GetLogEvent(_logger.Name, LogLevel.Debug, exception, format, args);
                LogRange(logEvent);
            }
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            if (_logger.IsErrorEnabled)
            {
                var logEvent = GetLogEvent(_logger.Name, LogLevel.Error, exception, format, args);
                LogRange(logEvent);
            }
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            if (_logger.IsFatalEnabled)
            {
                var logEvent = GetLogEvent(_logger.Name, LogLevel.Fatal, exception, format, args);
                LogRange(logEvent);
            }
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            if (_logger.IsInfoEnabled)
            {
                var logEvent = GetLogEvent(_logger.Name, LogLevel.Info, exception, format, args);
                LogRange(logEvent);
            }
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            if (_logger.IsTraceEnabled)
            {
                var logEvent = GetLogEvent(_logger.Name, LogLevel.Trace, exception, format, args);
                LogRange(logEvent);
            }
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            if (_logger.IsWarnEnabled)
            {
                var logEvent = GetLogEvent(_logger.Name, LogLevel.Warn, exception, format, args);
                LogRange(logEvent);
            }
        }

        public void Debug(Exception exception)
        {
            Debug(exception, string.Empty);
        }

        public void Error(Exception exception)
        {
            Error(exception, string.Empty);
        }

        public void Fatal(Exception exception)
        {
            Fatal(exception, string.Empty);
        }

        public void Info(Exception exception)
        {
            Info(exception, string.Empty);
        }

        public void Trace(Exception exception)
        {
            Trace(exception, string.Empty);
        }

        public void Warn(Exception exception)
        {
            Warn(exception, string.Empty);
        }

        public void Debug(string format, params object[] args)
        {
            Debug(null, format, args);
        }

        public void Error(string format, params object[] args)
        {
            Error(null, format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            Fatal(null, format, args);
        }

        public void Info(string format, params object[] args)
        {
            Info(null, format, args);
        }

        public void Trace(string format, params object[] args)
        {
            Trace(null, format, args); ;
        }

        public void Warn(string format, params object[] args)
        {
            Warn(null, format, args);
        }

        public void Flush()
        {
            LogManager.Flush();
        }

        public string LogFilePath()
        {
            try
            {
                foreach (var t in LogManager.Configuration.AllTargets)
                {
                    if (t is FileTarget)
                    {
                        var fileTarget = t as FileTarget;
                        var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
                        var fileName = fileTarget.FileName.Render(logEventInfo);
                        return fileName;
                    }
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private IEnumerable<LogEventInfo> GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            var result = new List<LogEventInfo>();
            int threadId;
            try
            {
                threadId = Thread.CurrentThread.ManagedThreadId;
            }
            catch
            {
                threadId = 0;
            }
            if (exception is AggregateException)
            {
                result.Add(new LogEventInfo(level, loggerName, string.Format("[thread id {0}] {1}", threadId, string.Format(format, args))) { Exception = exception });
                var aggregateException = exception as AggregateException;
                result.AddRange(aggregateException.InnerExceptions.Select(e => new LogEventInfo(level, loggerName, string.Format("[thread id {0}] {1}", threadId, string.Format(format, args))) { Exception = e }));
            }
            else
            {
                var logEvent = new LogEventInfo(level, loggerName, string.Format("[thread id {0}] {1}", threadId, string.Format(format, args))) { Exception = exception };
                result.Add(logEvent);
            }

            return result;
        }

        private void LogRange(IEnumerable<LogEventInfo> events)
        {
            foreach (var logEvent in events)
                _logger.Log(typeof(Logger), logEvent);
        }
    }
}
