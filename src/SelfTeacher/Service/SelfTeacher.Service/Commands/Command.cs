using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Domain.Entities.Enum;
using SelfTeacher.Service.Infrastructure.Service;
using ServiceTeacher.Service.Infrastructure.Exceptions;
using ServiceTeacher.Service.Infrastructure.Services;
using System;

namespace SelfTeacher.Service.Commands
{
    public abstract class Command : ICommand
    {
        #region Private fields
        private readonly ILogger _logger;
        #endregion

        #region Protected propertiens
        protected ILogger Logger
        {
            get { return _logger; }
        }
        #endregion

        #region ctor
        protected Command(ILogger logger)
        {
            _logger = logger;
        }
        #endregion

        #region Public methods
        public CommandResults Execute()
        {
            var result = new CommandResults();
            try
            {
                Run();
                result.Result = ECommandResults.Success;
            }
            catch(OperationCannotBePerformedException exception)
            {
                _logger.LogError(exception, exception.Message, new object());
                result.Result = ECommandResults.ObjectNotFound;
                result.Exception = exception;
                result.Message = exception.Message;
            }
            catch(Exception exception)
            {
                _logger.LogError(exception, exception.Message, new object());
                result.Result = ECommandResults.ServerFailedWithException;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }
        #endregion

        #region Protected methods
        protected abstract void Run();
        #endregion
    }

    public abstract class Command<T> : ICommand<T>
    {
        #region Private fields
        private readonly ILogger _logger;
        #endregion

        #region Public probably
        public ILogger Logger { get => _logger; }
        #endregion

        #region ctor

        public Command(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        #region public methods
        public CommandResults<T> Execute()
        {
            var result = new CommandResults<T>();
            try
            {
                result.Data = Run();
                result.Result = ECommandResults.Success;
            }
            catch (OperationCannotBePerformedException exception)
            {
                _logger.LogError(exception, exception.Message, new object());
                result.Result = ECommandResults.ObjectNotFound;
                result.Exception = exception;
                result.Message = exception.Message;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message, new object());
                result.Result = ECommandResults.ServerFailedWithException;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }
        #endregion

        #region Protected method

        protected abstract T Run();

        #endregion
    }
}
