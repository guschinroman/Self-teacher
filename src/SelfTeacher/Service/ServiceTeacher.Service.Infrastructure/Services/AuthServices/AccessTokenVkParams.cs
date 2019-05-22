using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Infrastructure.Services.AuthServices
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
     }
}
