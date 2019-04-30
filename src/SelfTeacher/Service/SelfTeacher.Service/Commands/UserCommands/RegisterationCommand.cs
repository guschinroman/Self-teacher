using AutoMapper;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Services;

namespace SelfTeacher.Service.Commands.UserCommands
{
    /// <summary>
    /// Registration command for service
    /// </summary>
    public class RegisterationCommand : Command
    {
        #region Private flelds
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserDto _userDto;
        #endregion

        #region ctor

        public RegisterationCommand(
            UserDto userDto,
            IUserService userService,
            IMapper mapper,
            ILogger logger)
            : base(logger)
        {
            _userDto = userDto;
            _userService = userService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        protected override void Run()
        {
            Logger.LogTrace($"Start command for registration user {_userDto.FirstName}");
            var user = _mapper.Map<User>(_userDto);
            
            _userService.Create(user, _userDto.Password);
            Logger.LogTrace($"Finish command for registration user {_userDto.FirstName} with OK responce");
        }
        #endregion
    }
}
