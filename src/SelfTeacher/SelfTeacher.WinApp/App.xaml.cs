using SelfTeacher.WinApp.Views;
using Prism.Ioc;
using System.Windows;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacher.WinApp.Infrastructure.Services.Localization;
using SelfTeacher.WinApp.Domain.Services.Settings;
using SelfTeacher.WinApp.Services.Settings;
using NLog;
using Prism.Mvvm;
using SelfTeacher.WinApp.Views.AuthView;
using SelfTeacher.WinApp.ViewModels;

namespace SelfTeacher.WinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILocalizationService, LocalizationService>();
            containerRegistry.Register<IWinAppSettingService, WinAppSettingsService>();
            containerRegistry.RegisterInstance(typeof(ILogger), NLog.LogManager.GetCurrentClassLogger());

            ViewModelLocationProvider.Register(typeof(AuthFormView).ToString(), typeof(AuthFormViewModel));


            var localizationService = Container.Resolve<ILocalizationService>();
            ResxExtension.GetResource += (name, key) =>
               {
                   return localizationService.Get(name, key);
               };
        }
    }
}
