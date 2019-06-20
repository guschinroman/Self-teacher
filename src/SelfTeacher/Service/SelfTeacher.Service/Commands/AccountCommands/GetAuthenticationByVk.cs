using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Domain.Services.Translators;
using System;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Commands.AccountCommands
{
    public class GetAuthenticationByVk : Command<AuthenticateDto>
    {
        #region Private fiends
        private readonly string _accessToken;
        private readonly ITranslator<User, UserDto> _userTranslator;
        private readonly IUserService _userService;
        #endregion

        #region ctor
        public GetAuthenticationByVk(
            string accessToken,
            ITranslator<User, UserDto> userTranslator,
            IUserService userService,
            ILogger logger)
            :base(logger)
        {
            _accessToken = accessToken;
            _userTranslator = userTranslator;
            _userService = userService;
        }

        #endregion

        #region Public methods
        protected override AuthenticateDto Run()
        {

            return _userService.AuthenticateByAccessTokenVk(_accessToken) as AuthenticateDto;
        }
        #endregion
    }
}
