using Microsoft.Extensions.Logging;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Commands.AccountCommands
{
    public class GetAddClientByVkCommand : AsyncCommand
    {
        #region private fields
        private readonly IVkAuthService _vkAuthService;
        private readonly string _code;
        #endregion

        #region ctor
        public GetAddClientByVkCommand(
            string code,
            IVkAuthService vkAuthService,
            ILogger logger)
            : base(logger)
        {
            _code = code;
            _vkAuthService = vkAuthService;
        }
        #endregion

        #region public methods
        protected async override Task Run()
        {
            Logger.LogTrace($"Start command GetAddClientByVkCommand with code {_code}");
            await _vkAuthService.GetAndSaveUser(_code);
        }

        #endregion
    }
}
