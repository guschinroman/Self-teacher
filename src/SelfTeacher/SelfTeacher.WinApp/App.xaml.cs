using SelfTeacher.WinApp.Views;
using Prism.Ioc;
using System.Windows;
using SelfTeacher.WinApp.Domain.Services;
using SelfTeacher.WinApp.Services.DiService;

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
            var diContainerService = new DiServiceInitializator(containerRegistry);
            diContainerService.InitDi();

            var initService = Container.Resolve<IInitManager>();

            initService.InitViewModel();
            initService.InitLocalization();
        }
    }
}
