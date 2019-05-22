using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SelfTeacher.Service.Helpers.DataContext;
using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Helpers;
using ServiceTeacher.Service.Domain.Services.AuthSerivce;
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
        private readonly string _accessCode;
        /// <summary>
        /// AccessToken after authentication
        /// </summary>
        private string _accessToken;

        private readonly DataContext _context;
        private readonly IAppSettings _settings;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        #endregion

        #region ctor
        public VkAuthService(
            DataContext context,
            IAppSettings settings,
            ILogger logger
            )
        {
            _context = context;
            _settings = settings;
            _logger = logger;

            _httpClient = new HttpClient();
        }
        #endregion

        #region public methods

        public User GetAndSaveUser(string code)
        {

        }
        #endregion

        #region private methods

        private async Task<string> AuthenticateUserInVk()
        {
            string access_token;

            var uriBuilder = new UriBuilder(_settings.VkAuth.AccessTokenAddress);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Set(AccessTokenVkParams.CLIENT_ID, _settings.VkAuth.VkAppId);
            query.Set(AccessTokenVkParams.CLIENT_SECRET, _settings.VkAuth.SecurityKey);
            query.Set(AccessTokenVkParams.CODE, _accessCode);
            query.Set(AccessTokenVkParams.REDIRECT_URI, "");
            uriBuilder.Query = query.ToString();
            JsonConvert.DeserializeObject
            var jsonString = await _httpClient.GetStringAsync(uriBuilder.ToString());

            return access_token;
        }
        #endregion
    }
}
