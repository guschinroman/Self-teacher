﻿using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Domain.Services.Translators;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Commands.AccountCommands
{
    public class GetAddClientByVkCommand : AsyncCommand<string>
    {
        #region private fields
        private readonly IVkAuthService _vkAuthService;
        private readonly string _code;
        private readonly ITranslator<User, UserDto> _userTranslator;
        #endregion

        #region ctor
        public GetAddClientByVkCommand(
            string code,
            ITranslator<User, UserDto> userTranslator,
            IVkAuthService vkAuthService,
            ILogger logger)
            : base(logger)
        {
            _code = code;
            _userTranslator = userTranslator;
            _vkAuthService = vkAuthService;
        }
        #endregion

        #region public methods
        protected async override Task<string> Run()
        {
            _logger.LogTrace($"Start command GetAddClientByVkCommand with code {_code}");
            return await _vkAuthService.GetAndSaveUser(_code);
        }

        #endregion
    }
}
