using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTeacher.Service.Infrastructure.Services.EmailService
{
    public class EmailSettings
    {
        /// <summary>
        /// Domain adress for smtp server
        /// </summary>
        public string MailServer { get; set; }
        /// <summary>
        /// Port for smtp server
        /// </summary>
        public int MainPort { get; set; }
        /// <summary>
        /// Sender name of account of smpt server
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// Sender name in mail
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// Password of account of smtp-server
        /// </summary>
        public string Password { get; set; }
    }
}
