using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.CommandFabric;
using SelfTeacher.Service.Infrastructure.Dtos;
using System;

namespace SelfTeacher.Service.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        #region Private fields
        private readonly UserCommandFabric _userCommandFactory;
        #endregion

        #region Constructor
        public UsersController(
            UserCommandFabric userCommandFabric,
            ILogger<BaseController> logger)
            :base(logger)
        {
            _userCommandFactory = userCommandFabric;
            Logger = logger;
        }
        #endregion

        #region Public Actions

        /// <summary>
        /// Method for authenticate
        /// </summary>
        /// <param name="userParam"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userParam)
        {
            Logger.LogTrace($"Get request for auth command for user {userParam.Username}");
            return Process(_userCommandFactory.GetAuthCommand(userParam).Execute());
        }

        /// <summary>
        /// Method for registration
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Registration([FromBody]UserDto userDto)
        {
            Logger.LogTrace($"Get request for registration command for user {userDto.Username}");
            return Process(_userCommandFactory.GetRegister(userDto).Execute());
        }

        /// <summary>
        /// Method for get all user in system
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetAll()
        {
            Logger.LogTrace($"Get request for get all users");
            return Process(_userCommandFactory.GetAllUsers().Execute());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            Logger.LogTrace($"Get request for get one user by id {id}");
            return Process(_userCommandFactory.GetUserById(id).Execute());
        }


        [HttpPut("{id:guid}")]
        public IActionResult UpdateUserById(Guid id, [FromBody]UserDto userDto)
        {
            Logger.LogTrace($"Get request for update user with id {id}");
            return Process(_userCommandFactory.GetUpdateUser(id, userDto).Execute());
        }
        #endregion
    }
}