using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.CommandFabric;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Services;

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
            return Process(_userCommandFactory.GetRegister(userDto).Execute());
        }

        /// <summary>
        /// Method of get all users in system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        #endregion
    }
}