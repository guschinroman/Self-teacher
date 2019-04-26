using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private IUserService _userService;
        #endregion

        #region Constructor
        public UsersController(IUserService userService, ILogger<BaseController> logger)
            :base(logger)
        {
            _userService = userService;
        }
        #endregion

        #region Public Actions

        /// <summary>
        /// Method of authenticate
        /// </summary>
        /// <param name="userParam"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if(user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(user);
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