using ServiceTeacher.Service.Domain.Entities;
using ServiceTeacher.Service.Domain.Entities.EmailService;

namespace ServiceTeacher.Service.Domain.Helpers
{
    /// <summary>
    /// Interface of web server settings
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Secret for authentification settings
        /// </summary>
        string Secret { get; set; }

        /// <summary>
        /// Email account sender
        /// </summary>
        EmailSettings EmailAccountSender { get; set; }

        /// <summary>
        /// Vk uathentuication settings
        /// </summary>
        VkAuthSettings VkAuth { get; set; }
    }
}
