using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
