using ServiceTeacher.Service.Domain.Helpers;

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
    }
}
