using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Infrastructure.Exceptions;

namespace SelfTeacher.Service.Commands.UserCommands
{
    /// <summary>
    /// Command for authentication
    /// </summary>
    public class AuthenticationCommand : Command<AuthenticateDto>
    {
        #region Private flelds
        private readonly IUserService _userService;
        private readonly UserDto _userDto;
        #endregion

        #region ctor

        public AuthenticationCommand(
            UserDto userDto,
            IUserService userService,
            ILogger logger)
            :base(logger)
        {
            _userDto = userDto;
            _userService = userService;
        }
        #endregion

        #region Methods
        protected override AuthenticateDto Run()
        {

            Logger.LogTrace($"Start command for auth user {_userDto.Username}");
            AuthenticateDto user = (AuthenticateDto)_userService.Authenticate(_userDto.Username, _userDto.Password);

            if (user == null)
            {
                throw new OperationCannotBePerformedException("User don't exist");
            }

            Logger.LogTrace($"Finish auth command for user {_userDto.Username} with Ok responce");
            return user;
        }
        #endregion
    }
}
