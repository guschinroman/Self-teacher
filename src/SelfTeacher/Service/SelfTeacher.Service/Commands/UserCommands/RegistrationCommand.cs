﻿using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Entities.Enum;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.EmailService;
using ServiceTeacher.Service.Domain.Services.Translators;
using System;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Commands.UserCommands
{
    /// <summary>
    /// Registration command for service
    /// </summary>
    public class RegistrationCommand : AsyncCommand
    {
        #region Private flelds
        private readonly IUserService _userService;
        private readonly ITranslator<UserDto, User> _userTranslator;
        private readonly IClientEmailSender _clientEmailSender;
        private readonly UserDto _userDto;
        #endregion

        #region ctor

        public RegistrationCommand(
            UserDto userDto,
            IUserService userService,
            ITranslator<UserDto, User> userTranslator,
            IClientEmailSender clientEmailSender,
            ILogger logger)
            : base(logger)
        {
            _userDto = userDto;
            _userService = userService;
            _userTranslator = userTranslator;
            _clientEmailSender = clientEmailSender;
        }
        #endregion

        #region Methods
        protected override async Task Run()
        {
            Logger.LogTrace($"Start command for registration user {_userDto.FirstName}");
            var user = _userTranslator.Translate(_userDto);

            user.ConfirmCode = Guid.NewGuid().ToString();

            _userService.Create(user, _userDto.Password);

            await _clientEmailSender.SendConfirmRegistrationEmail(user.Email, $"{user.Firstname} {user.Lastname}", user.ConfirmCode);

            Logger.LogTrace($"Finish command for registration user {_userDto.FirstName} with OK responce");
        }
        #endregion
    }
}
