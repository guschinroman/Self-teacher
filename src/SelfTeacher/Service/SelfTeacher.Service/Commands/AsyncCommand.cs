using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Domain.Entities.Enum;
using SelfTeacher.Service.Infrastructure.Service;
using ServiceTeacher.Service.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Commands
{
    public abstract class AsyncCommand : IAsyncCommand
    {
        private readonly ILogger _logger;

        protected ILogger Logger
        {
            get { return _logger; }
        }

        protected AsyncCommand(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<ICommandCommonResults> Execute()
        {
            var results = new CommandResults();
            try
            {
                await Run();
                results.Result = ECommandResults.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, new object[] { });
                results.Result = ECommandResults.ServerFailedWithException;
                results.Message = ex.Message;
            }

            return results;
        }

        protected abstract Task Run();
    }

    public abstract class AsyncCommand<T> : IAsyncCommand<T>
    {
        protected readonly ILogger _logger;

        protected AsyncCommand(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<ICommandDataResults<T>> Execute()
        {
            var results = new CommandResults<T>();
            try
            {
                var data = await Run();
                results.Result = ECommandResults.Success;
                results.Data = data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, new object[] { });
                results.Result = ECommandResults.ServerFailedWithException;
                results.Message = ex.Message;
            }

            return results;
        }

        protected abstract Task<T> Run();
    }
}
