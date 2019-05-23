using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Infrastructure.Services.AuthServices
{
    public class VkAccessTokenDto
    {
        /// <summary>
        /// Access token for request to vk api
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Time to live of access token
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// authenticated user ID
        /// </summary>
        public int user_id { get; set; }
    }
}
