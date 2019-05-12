using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services;
using System;

namespace SelfTeacher.Service.Commands.UserCommands
{
    /// <summary>
    /// Command for update user info
    /// </summary>
    public class UpdateUserCommand : Command
    {
        #region private fields
        private readonly Guid _id;
        private readonly UserDto _userDto;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        #endregion

        #region ctor
        public UpdateUserCommand(
            Guid id,
            UserDto userDto,
            IUserService userService,
            IMapper mapper,
            ILogger logger): base (logger)
        {
            this._id = id;
            this._userDto = userDto;
            this._userService = userService;
            this._mapper = mapper;
            this._logger = logger;
        }
        #endregion

        #region public method
        protected override void Run()
        {
            Logger.LogTrace("Start command for update user info");

            try
            {
                var user = _mapper.Map<User>(_userDto);

                _userService.Update(user);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Error on update user");
            }

            Logger.LogTrace("End command for update user info");
        }
        #endregion
    }
}
