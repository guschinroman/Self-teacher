using Microsoft.Extensions.Logging;
using ServiceTeacher.Service.Domain.Services;
using System;

namespace SelfTeacher.Service.Commands.UserCommands
{
    public class ConfirmRegistrationCommand: Command
    {
        #region private fields
        private readonly IUserService _userService;
        private readonly string _code;
        private readonly string _userId;
        #endregion

        #region ctor
        public ConfirmRegistrationCommand(
            string code,
            string userId,
            IUserService userService,
            ILogger logger)
            :base(logger)
        {
            _code = code;
            _userId = userId;
            _userService = userService;
        }
        #endregion

        #region public method
        protected override void Run()
        {
            Logger.LogTrace($"Start command confirm registration command with code {_code} and user id {_userId}");

            try
            {
                _userService.ConfirmUser(Guid.Parse(_userId), _code);
                Logger.LogTrace("Confirmation user ended succesfully");
            }
            catch(Exception ex)
            {
                Logger.LogTrace(ex, "Command of confirmation failed");
            }

            Logger.LogTrace($"End command confirm registration command with code {_code} and user id {_userId}");
        }
        #endregion
    }
}
