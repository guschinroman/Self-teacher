using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Infrastructure.Services.AuthServices
{
    public class VkUserDto
    {
        /// <summary>
        /// Name of user
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// last name of user
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Email of user
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        public int uid { get; set; }
    }
}
