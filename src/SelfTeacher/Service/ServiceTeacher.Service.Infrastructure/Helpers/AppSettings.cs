using ServiceTeacher.Service.Domain.Helpers;
using ServiceTeacher.Service.Infrastructure.Services.EmailService;

namespace ServiceTeacher.Service.Infrastructure.Helpers
{
    /// <summary>
    /// Current implementation of application settings
    /// </summary>
    public class AppSettings: IAppSettings
    {
        /// <summary>
        /// Secret for athentication task
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Setting of email account for notifications
        /// </summary>
        public EmailSettings EmailAccountSender { get; set; }
    }
}
