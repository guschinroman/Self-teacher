using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.Translators;
using System.Collections.Generic;

namespace SelfTeacher.Service.Commands.UserCommands
{
    public class GetAllUserCommand : Command<ICollection<UserDto>>
    {
        #region private fields
        private readonly IUserService _userService;
        private readonly ITranslator<User, UserDto> _userTranslator;
        #endregion

        #region ctor
        public GetAllUserCommand(
            IUserService userService,
            ITranslator<User, UserDto> userTranslator,
            ILogger logger
            ) : base(logger)
        {
            this._userService = userService;
            _userTranslator = userTranslator;
        }
        #endregion

        #region public methods
        protected override ICollection<UserDto> Run()
        {
            Logger.LogTrace("Start commad of get all users in system");
            var users = _userService.GetAll();
            var userDtos = new List<UserDto>();

            foreach(var user in users)
            {
                userDtos.Add(_userTranslator.Translate(user));
            }

            Logger.LogTrace("End command of get all users in system");

            return userDtos;
        }
        #endregion
    }
}
