using System;
using System.Collections.Generic;
using System.Text;

namespace SelfTeacher.WinApp.Domain.Services
{
    public interface IInitManager
    {
        /// <summary>
        /// Initializing View Model to View
        /// </summary>
        void InitViewModel();

        /// <summary>
        /// Initializion regions manager
        /// </summary>
        void InitRegions()

    }
}
