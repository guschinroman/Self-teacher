using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.Translators;
using System;

namespace SelfTeacher.Service.Commands.UserCommands
{
    /// <summary>
    /// Command for getting user by id
    /// </summary>
    public class GetUserByIdCommand : Command<UserDto>
    {
        #region private fields
        private readonly Guid _id;
        private readonly IUserService _userService;
        private readonly ITranslator<User, UserDto> _userTranslator;
        #endregion

        #region ctor
        public GetUserByIdCommand(
            Guid id,
            IUserService userService,
            ITranslator<User, UserDto> userTranslator,
            ILogger logger
            ): base (logger)
        {
            _id = id;
            _userService = userService;
            _userTranslator = userTranslator;
        }
        #endregion

        #region public method
        protected override UserDto Run()
        {
            Logger.LogTrace("Start command for getting user by id");
            UserDto user = null;

            try
            {
                user = _userTranslator.Translate(_userService.GetById(_id));
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "cannot find user");
            }
            finally
            {
                Logger.LogTrace("End command fort getting user by id");
            }

            return user;
        }
        #endregion
    }
}
