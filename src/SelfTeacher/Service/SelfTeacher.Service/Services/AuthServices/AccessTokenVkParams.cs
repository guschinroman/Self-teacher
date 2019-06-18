using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Services.AuthServices
{
    public class AccessTokenVkParams
    {
        /// <summary>
        /// Application id
        /// </summary>
        public static string CLIENT_ID => "client_id";

        /// <summary>
        /// Application secret id
        /// </summary>
        public static string CLIENT_SECRET => "client_secret";

        /// <summary>
        /// Code from vk
        /// </summary>
        public static string CODE => "code";

        /// <summary>
        /// Redirect uri
        /// </summary>
        public static string REDIRECT_URI => "redirect_uri";

        /// <summary>
        /// User id in VK
        /// </summary>
        public static string USER_ID => "uids";

        /// <summary>
        /// Fields from VK
        /// </summary>
        public static string FIELDS_FROM_VK => "fileds";

        /// <summary>
        /// Access token for VK auth
        /// </summary>
        public static string ACCESS_TOKEN => "access_token";

        /// <summary>
        /// Value of fields for vk
        /// </summary>
        public static string FIELDS_FROM_VK_VALUE => "uid,first_name,last_name,email";

        /// <summary>
        /// Required params version name
        /// </summary>
        public static string VERSION_NAME => "v";

        /// <summary>
        /// Version params version value
        /// </summary>
        public static string VERSION_VALUE => "5.95";
     }
}
