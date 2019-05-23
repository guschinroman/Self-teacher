using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Domain.Entities
{
    public class VkAuthSettings
    {
        /// <summary>
        /// Redirect URL for vk auth
        /// </summary>
        public string RedirectUrl { get; set; }
        /// <summary>
        /// address of vk api
        /// </summary>
        public string AuthAdress { get; set; }

        /// <summary>
        /// address of vk access token
        /// </summary>
        public string AccessTokenAddress { get; set; }

        public  string AccessToUserGetVk { get; set; }
        /// <summary>
        /// ID application in VK
        /// </summary>
        public string VkAppId { get; set; }

        /// <summary>
        /// SecurityKey of application
        /// </summary>
        public string SecurityKey { get; set; }

        /// <summary>
        /// Server entry key
        /// </summary>
        public string ServerEntryKey { get; set; }
    }
}
