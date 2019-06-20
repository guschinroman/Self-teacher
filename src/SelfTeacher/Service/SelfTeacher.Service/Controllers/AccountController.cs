using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfTeacher.Service.CommandFabric;
using System.Threading.Tasks;

namespace SelfTeacher.Service.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseController
    {
        #region Private fields
        private readonly AccountCommandFabric _accountCommandFabric;
        #endregion

        #region Constructor
        public AccountController(
            AccountCommandFabric accountCommandFabric,
            ILogger<BaseController> logger)
            :base(logger)
        {
            _accountCommandFabric = accountCommandFabric;
            Logger = logger;
        }
        #endregion

        #region Public Actions

        /// <summary>
        /// Method for send authenticate vk link
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("get-vk-authenticate-link")]
        public IActionResult AuthenticateByVk()
        {
            Logger.LogTrace($"Get request for send vk auth link");
            return Process(_accountCommandFabric.GetGetVkAuthLink().Execute());
        }

        [AllowAnonymous]
        [HttpGet("add-auth-client-vk")]
        public async Task<IActionResult> AddAuthClientByVk(string code)
        {
            Logger.LogTrace($"Get request for auth user by vk and save in database");
            if(code == null || code == "")
            {
                return new EmptyResult();
            }

            var userDto = await _accountCommandFabric.GetGetAddClientByVk(code).Execute();

            return  Redirect($"http://localhost:8080/#/vkConfirmAuthentication/{userDto.Data}");
        }

        [AllowAnonymous]
        [HttpGet("authenticate-vk/{accessToken}")]
        public IActionResult AuthenticateVk(string accessToken)
        {
            Logger.LogTrace($"Get request for authentication vk with access token");

            return Process(_accountCommandFabric.GetGetAuthenticationByVk(accessToken).Execute());
        }

        #endregion
    }
}