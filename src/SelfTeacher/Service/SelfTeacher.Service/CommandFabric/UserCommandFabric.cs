using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Commands.UserCommands;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.EmailService;
using ServiceTeacher.Service.Infrastructure.Services;
using System;
using System.Collections.Generic;

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
        private readonly IClientEmailSender _clientEmailSender;
        #endregion

        #region ctor
        public UserCommandFabric(
            IUserService userService,
            IMapper mapper,
            IClientEmailSender clientEmailSender,
            ILogger<UserCommandFabric> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _clientEmailSender = clientEmailSender;
            _logger = logger;
        }
        #endregion

        #region Public methods

        public ICommand<AuthenticateDto> GetAuthCommand(UserDto userDto)
        {
            return new AuthenticationCommand(userDto, _userService, _logger);
        }

        public IAsyncCommand GetRegister(UserDto userDto)
        {
            return new RegistrationCommand(userDto, _userService, _mapper, _clientEmailSender, _logger);
        }

        public ICommand GetConfirmRegistration(string userId, string code)
        {
            return new ConfirmRegistrationCommand(code, userId, _userService, _logger);
        }

        public ICommand<ICollection<UserDto>> GetAllUsers()
        {
            return new GetAllUserCommand(_userService, _mapper, _logger);
        }

        public ICommand<UserDto> GetUserById(Guid id)
        {
            return new GetUserByIdCommand(id, _userService, _mapper, _logger);
        }

        public ICommand GetUpdateUser(Guid id, UserDto user)
        {
            return new UpdateUserCommand(id, user, _userService, _mapper, _logger);
        }
        #endregion
    }
}
