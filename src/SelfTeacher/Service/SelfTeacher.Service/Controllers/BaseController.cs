using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Commands.Entity;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Controllers
{
    public class BaseController : Controller
    {
        #region Private fields
        /// <summary>
        /// Logger for controllers
        /// </summary>
        private readonly ILogger<BaseController> _logger;
        #endregion

        #region Public properties

        public ILogger<BaseController> Logger { get; set; }
        #endregion

        #region constructor
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
        #endregion regions

        #region Protected methods

        protected async Task<IActionResult> ProcessAsync(Task<ICommandCommonResults> commandResults)
        {
            var result = await commandResults;
            if (commandResults.Exception == null)
                return !IsResultOk(result) ? Failed(result) : Ok();

            Logger.LogError(commandResults.Exception, "", new object());
            return Failed(new CommandResults { Result = ECommandResults.ServerFailedWithException, Message = commandResults.Exception.Message });
        }

        protected async Task<IActionResult> ProcessAsync<T>(Task<ICommandDataResults<T>> commandResults)
        {
            var result = await commandResults;
            if (commandResults.Exception == null)
                return !IsResultOk(result) ? Failed(result) : Ok(result.Data);

            Logger.LogError(commandResults.Exception, "", new object());
            return Failed(new CommandResults { Result = ECommandResults.ServerFailedWithException, Message = commandResults.Exception.Message });
        }

        protected IActionResult Process(ICommandCommonResults commandResults)
        {
            return !IsResultOk(commandResults) ? Failed(commandResults) : Ok();
        }

        protected IActionResult Process<T>(ICommandDataResults<T> commandResults)
        {
            if (!IsResultOk(commandResults))
                return Failed(commandResults);

            return Ok(commandResults.Data);
        }

        private bool IsResultOk(ICommandCommonResults commandResults)
        {
            return commandResults.Result == ECommandResults.Success;
        }

        private IActionResult Failed(ICommandCommonResults commandResults)
        {
            IActionResult response = null;
            switch (commandResults.Result)
            {
                case ECommandResults.ServerFailedWithException:
                    response = StatusCode(500, commandResults.Message);
                    break;
                case ECommandResults.ObjectNotFound:
                    response = NotFound(commandResults.Message);
                    break;
                case ECommandResults.OperationCanNotBePerformed:
                    response = Forbid(commandResults.Message);
                    break;
                default:
                    var errorText = "Unexpected command result: " + commandResults.Result;
                    _logger.LogError(errorText);
                    response = StatusCode(500, errorText);
                    break;
            }
            return response;
        }

        #endregion
    }
}
