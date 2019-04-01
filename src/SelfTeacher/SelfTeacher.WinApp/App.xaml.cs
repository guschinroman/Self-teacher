using SelfTeacher.WinApp.Views;
using Prism.Ioc;
using System.Windows;
using CommonServiceLocator;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacher.WinApp.Services.Localization;

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

        }

        private void OnApplicationStarted(object sender, StartupEventArgs e)
        {
            var localizationService = ServiceLocator.Current.GetInstance<ILocalizationService>();

            ResxExtension.GetResource += (name, key) => localizationService.Get(name, key);
        }


    }
}
