﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Commands.AccountCommands;
using ServiceTeacher.Service.Domain.Helpers;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Domain.Services.EmailService;
using ServiceTeacher.Service.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfTeacher.Service.CommandFabric
{
    public class AccountCommandFabric
    {
        #region Private fields
        private readonly IUserService _userService;
        private readonly IAppSettings _appSettings;
        private readonly IVkAuthService _vkAuthService;
        private readonly IMapper _mapper;
        private readonly IClientEmailSender _clientEmailSender;
        private readonly ILogger<AccountCommandFabric> _logger;
        #endregion

        #region ctor
        public AccountCommandFabric(
            IUserService userService,
            IAppSettings appSettings,
            IVkAuthService vkAuthService,
            IMapper mapper,
            IClientEmailSender clientEmailSender,
            ILogger<AccountCommandFabric> logger)
        {
            _userService = userService;
            _appSettings = appSettings;
            _vkAuthService = vkAuthService;
            _mapper = mapper;
            _clientEmailSender = clientEmailSender;
            _logger = logger;
        }
        #endregion

        #region public methods

        public ICommand<string> GetGetVkAuthLink()
        {
            return new GetAuthVkLinkCommand(_appSettings, _logger);
        }

        public IAsyncCommand GetGetAddClientByVk(string code)
        {
            return new GetAddClientByVkCommand(code, _vkAuthService, _logger);
        }

        #endregion
    }
}
