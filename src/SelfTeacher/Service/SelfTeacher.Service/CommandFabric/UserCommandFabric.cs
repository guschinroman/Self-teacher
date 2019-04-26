using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Commands.UserCommands;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Infrastructure.Services;

namespace SelfTeacher.Service.CommandFabric
{
    /// <summary>
    /// Command fabric for user account actions
    /// </summary>
    public class UserCommandFabric
    {
        #region Private fields
        private readonly ILogger<UserCommandFabric> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public UserCommandFabric(
            IUserService userService,
            IMapper mapper,
            ILogger<UserCommandFabric> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Public methods

        public ICommand<AuthenticateDto> GetAuthCommand(UserDto userDto)
        {
            return new AuthenticationCommand(userDto, _userService, _logger);
        }

        public ICommand GetRegister(UserDto userDto)
        {
            return new RegisterationCommand(userDto, _userService, _mapper, _logger);
        }

        #endregion
    }
}
