using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SelfTeacher.Service.Helpers.DataAccess;
using SelfTeacher.Service.Infrastructure.Dtos;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Helpers;
using ServiceTeacher.Service.Domain.Services;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
using ServiceTeacher.Service.Domain.Services.Translators;
using ServiceTeacher.Service.Services.AuthServices;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ServiceTeacher.Service.Infrastructure.Services.AuthServices
{
    public class VkAuthService : IVkAuthService
    {
        #region private fields
        /// <summary>
        /// Access code from VK
        /// </summary>
        private string _accessCode;

        private readonly DataContext _context;
        private readonly IAppSettings _settings;
        private readonly ITranslator<VkUserDto, User> _translator;
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private VkAccessTokenDto _vkAccessTokenDto;

        #endregion

        #region ctor
        public VkAuthService(
            DataContext context,
            IAppSettings settings,
            IUserService userService,
            ITranslator<VkUserDto, User> translator,
            ILogger<VkAuthService> logger
            )
        {
            _context = context;
            _settings = settings;
            _translator = translator;
            _userService = userService;
            _logger = logger;

            _httpClient = new HttpClient();
        }
        #endregion

        #region public methods

        public async Task<string> GetAndSaveUser(string code)
        {
            _accessCode = code;
            _vkAccessTokenDto = await AuthenticateUserInVk();
            var user = await GetUserFromVk(_vkAccessTokenDto);
            user.Id = Guid.NewGuid();

            var authDto = _userService.CreateVkUser(user);

            return authDto;
        }
        #endregion

        #region private methods

        private async Task<VkAccessTokenDto> AuthenticateUserInVk()
        {
            _logger.LogTrace("Start create query for getting access_token");
            var uriBuilder = new UriBuilder(_settings.VkAuth.AccessTokenAddress);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Set(AccessTokenVkParams.CLIENT_ID, _settings.VkAuth.VkAppId);
            query.Set(AccessTokenVkParams.CLIENT_SECRET, _settings.VkAuth.SecurityKey);
            query.Set(AccessTokenVkParams.CODE, _accessCode);
            query.Set(AccessTokenVkParams.REDIRECT_URI, _settings.VkAuth.RedirectUrl);
            uriBuilder.Query = query.ToString();
            _logger.LogTrace($"Getting query {uriBuilder.Query}");

            var accessDto = JsonConvert.DeserializeObject<VkAccessTokenDto>(await _httpClient.GetStringAsync(uriBuilder.ToString()));

            _logger.LogTrace($"Getting responce with info access_token - {accessDto.access_token}, expires_in - {accessDto.expires_in}, user_id - {accessDto.user_id}");

            return accessDto;
        }

        private async Task<User> GetUserFromVk(VkAccessTokenDto vkAccessTokenDto)
        {
            _logger.LogTrace("Start create query for getting user from VK");

            var uriBuilder = new UriBuilder(_settings.VkAuth.AccessToUserGetVk);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Set(AccessTokenVkParams.USER_ID, vkAccessTokenDto.user_id.ToString());
            query.Set(AccessTokenVkParams.FIELDS_FROM_VK, AccessTokenVkParams.FIELDS_FROM_VK_VALUE);
            query.Set(AccessTokenVkParams.ACCESS_TOKEN, vkAccessTokenDto.access_token);
            query.Set(AccessTokenVkParams.VERSION_NAME, AccessTokenVkParams.VERSION_VALUE);
            uriBuilder.Query = query.ToString();

            _logger.LogTrace($"Getting query {uriBuilder.Query}");
            var vkAnswer = await _httpClient.GetStringAsync(uriBuilder.ToString());
            var responce = new { response = new VkUserDto[1] };
            var vkUserDto = JsonConvert.DeserializeAnonymousType(vkAnswer, responce).response[0];

            vkUserDto.access_token = vkAccessTokenDto.access_token;

            _logger.LogTrace($"Getting responce with info first_name - {vkUserDto.first_name}, last_name - {vkUserDto.last_name}");

            return _translator.Translate(vkUserDto);

        }
        #endregion
    }
}
