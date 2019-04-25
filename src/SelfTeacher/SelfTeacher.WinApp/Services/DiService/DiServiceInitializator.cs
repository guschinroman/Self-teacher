using NLog;
using Prism.Ioc;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacher.WinApp.Domain.Services;
using SelfTeacher.WinApp.Domain.Services.Settings;
using SelfTeacher.WinApp.Infrastructure.Services.Localization;
using SelfTeacher.WinApp.Services.Settings;
using SelfTeacher.WinApp.ViewModels;
using SelfTeacher.WinApp.Views;
using SelfTeacher.WinApp.Views.AuthView;
using SelfTeacher.WinApp.Views.Common;
using SelfTeacherWinApp.Infrastructure.Services;
using SelfTeacherWinApp.WinApp.Services;

namespace SelfTeacher.WinApp.Services.DiService
{
    public class DiServiceInitializator
    {
        #region private fields
        /// <summary>
        /// DI container registry
        /// </summary>
        private readonly IContainerRegistry _containerRegistry;
        #endregion

        #region constructor
        public DiServiceInitializator(IContainerRegistry containerRegistry)
        {
            this._containerRegistry = containerRegistry;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Method for init di container DryIoc
        /// </summary>
        public void InitDi()
        {
            initServices();
            initTraslators();
            initNavigation();
        }

        #endregion

        #region private methods
        /// <summary>
        /// Method for binding services of application
        /// </summary>
        private void initServices()
        {
            _containerRegistry.RegisterSingleton<ILocalizationService, LocalizationService>();

            _containerRegistry.Register<IWinAppSettingService, WinAppSettingsService>();

            _containerRegistry.RegisterInstance(typeof(ILogger), NLog.LogManager.GetCurrentClassLogger());

            _containerRegistry.Register<IInitManager, InitManager>();

            _containerRegistry.Register<IRegionNameService, RegionNameService>();

            _containerRegistry.Register<IViewModelNameService, ViewModelNameService>();
        }
        /// <summary>
        /// Method for binding translator PE to DTO of application
        /// </summary>
        private void initTraslators()
        {

        }

        /// <summary>
        /// Method for binding navigation possible view
        /// </summary>
        private void initNavigation()
        {
            _containerRegistry.RegisterForNavigation<MainWindow>("MainWindow");
            _containerRegistry.RegisterForNavigation<AuthFormView>("AuthFormView");
            _containerRegistry.RegisterForNavigation<LanguageElementView>("LanguageElementView");
            _containerRegistry.RegisterForNavigation<AuthView>("AuthView");
            _containerRegistry.RegisterForNavigation<RegisterFormView>("RegisterFormView");
        }
        #endregion
    }
}
