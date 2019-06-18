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
        /// User id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Closed connection
        /// </summary>
        public bool is_closed { get; set; }
        /// <summary>
        /// Logout
        /// </summary>
        public bool can_access_closed { get; set; }
    }
}
