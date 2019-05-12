using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Services;
using System.Collections.Generic;

namespace SelfTeacher.Service.Commands.UserCommands
{
    public class GetAllUserCommand : Command<ICollection<UserDto>>
    {
        #region private fields
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public GetAllUserCommand(
            IUserService userService,
            IMapper mapper,
            ILogger logger
            ) : base(logger)
        {
            this._userService = userService;
            this._mapper = mapper;
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
                userDtos.Add(_mapper.Map<UserDto>(user));
            }

            Logger.LogTrace("End command of get all users in system");

            return userDtos;
        }
        #endregion
    }
}
