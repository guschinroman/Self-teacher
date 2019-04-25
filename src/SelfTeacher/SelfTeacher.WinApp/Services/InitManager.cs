using Prism.Mvvm;
using Prism.Regions;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacher.WinApp.Domain.Services;
using SelfTeacher.WinApp.Infrastructure.Services.Localization;
using SelfTeacher.WinApp.ViewModels;
using SelfTeacher.WinApp.Views.AuthView;
using SelfTeacher.WinApp.Views.Common;
using System;

namespace SelfTeacherWinApp.WinApp.Services
{
    /// <summary>
    /// Service class for maintain init application
    /// </summary>
    public class InitManager : IInitManager
    {
        #region Private property

        /// <summary>
        /// Region
        /// </summary>
        private readonly IRegionManager _regionManager;
        private readonly IRegionNameService _regionNameService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Constructor
        public InitManager(IRegionManager regionManager,
            IRegionNameService regionNameService,
            ILocalizationService localizationService)
        {
            this._regionManager = regionManager;
            this._regionNameService = regionNameService;
            this._localizationService = localizationService;
        }
        #endregion

        #region public methods

        /// <summary>
        /// Initizalization application prism regions
        /// </summary>
        public void InitRegions()
        {
            if (_regionManager == null)
            {
                throw new ArgumentNullException(nameof(_regionManager));
            }
            _regionManager.RegisterViewWithRegion(_regionNameService.LanguageChangeRegion, typeof(LanguageElementView));
            _regionManager.RegisterViewWithRegion(_regionNameService.AuthRegion, typeof(AuthView));
            _regionManager.RegisterViewWithRegion(_regionNameService.AuthFormRegion, typeof(AuthFormView));

        }

        /// <summary>
        /// Initialization of prism di for view models
        /// </summary>
        public void InitViewModel()
        {
            ViewModelLocationProvider.Register(typeof(AuthFormView).ToString(), typeof(AuthFormViewModel));
            ViewModelLocationProvider.Register(typeof(RegisterFormView).ToString(), typeof(RegisterFormViewModel));
        }

       public void InitLocalization()
       {
            ResxExtension.GetResource += (name, key) =>
            {
                return _localizationService.Get(name, key);
            };
        }

        #endregion
    }
}
