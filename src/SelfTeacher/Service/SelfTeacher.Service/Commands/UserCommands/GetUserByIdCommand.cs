using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Services;
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
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public GetUserByIdCommand(
            Guid id,
            IUserService userService,
            IMapper mapper,
            ILogger logger
            ): base (logger)
        {
            this._id = id;
            this._userService = userService;
            this._mapper = mapper;
        }
        #endregion

        #region public method
        protected override UserDto Run()
        {
            Logger.LogTrace("Start command for getting user by id");
            UserDto user = null;

            try
            {
                user = _mapper.Map<UserDto>(_userService.GetById(_id));
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
