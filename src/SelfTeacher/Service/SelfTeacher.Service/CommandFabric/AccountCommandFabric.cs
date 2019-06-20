
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Commands.AccountCommands;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Helpers;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Domain.Services.EmailService;
using ServiceTeacher.Service.Domain.Services.Translators;
using ServiceTeacher.Service.Infrastructure.Services;

namespace SelfTeacher.Service.CommandFabric
{
    public class AccountCommandFabric
    {
        #region Private fields
        private readonly IUserService _userService;
        private readonly IAppSettings _appSettings;
        private readonly IVkAuthService _vkAuthService;
        private readonly ITranslator<User, UserDto> _userTranslator;
        private readonly IClientEmailSender _clientEmailSender;
        private readonly ILogger<AccountCommandFabric> _logger;
        #endregion

        #region ctor
        public AccountCommandFabric(
            IUserService userService,
            IAppSettings appSettings,
            IVkAuthService vkAuthService,
            ITranslator<User, UserDto> userTranslator,
            IClientEmailSender clientEmailSender,
            ILogger<AccountCommandFabric> logger)
        {
            _userService = userService;
            _appSettings = appSettings;
            _vkAuthService = vkAuthService;
            _userTranslator = userTranslator;
            _clientEmailSender = clientEmailSender;
            _logger = logger;
        }
        #endregion

        #region public methods

        public ICommand<string> GetGetVkAuthLink()
        {
            return new GetAuthVkLinkCommand(_appSettings, _logger);
        }

        public IAsyncCommand<string> GetGetAddClientByVk(string code)
        {
            return new GetAddClientByVkCommand(code, _userTranslator, _vkAuthService, _logger);
        }

        public ICommand<AuthenticateDto> GetGetAuthenticationByVk(string accessToken)
        {
            return new GetAuthenticationByVk(accessToken, _userTranslator, _userService, _logger);
        }

        #endregion
    }
}
