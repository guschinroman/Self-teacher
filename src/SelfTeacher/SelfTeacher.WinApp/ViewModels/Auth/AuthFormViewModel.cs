using Prism.Mvvm;
using Prism.Regions;
using SelfTeacher.WinApp.Command.WpfCommand;
using SelfTeacher.WinApp.Domain.Services;
using SelfTeacher.WinApp.Domain.Services.Settings;
using SelfTeacher.WinApp.PE;
using System;
using System.Windows.Input;

namespace SelfTeacher.WinApp.ViewModels
{
    public class AuthFormViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region Private member
        private readonly IRegionManager _regionManager;
        private readonly IRegionNameService _regionNameService;
        private readonly IViewModelNameService _viewModelNameService;
        #endregion

        #region Public Properties

        public LoginPe LoginPe { get; set; }

        public ICommand GoToRegistrationCommand { get; }

        public bool KeepAlive => false;

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public AuthFormViewModel(IRegionManager regionManager,
            IRegionNameService regionNameService,
            IViewModelNameService viewModelNameService)
        {
            GoToRegistrationCommand = new RelayCommand(() => goToRegistrationCommand());
            _regionManager = regionManager;
            _regionNameService = regionNameService;
            _viewModelNameService = viewModelNameService;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Method before make view deactive
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// Nav target on navigation request
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// Method before make view active
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Comman for change view to registration view
        /// </summary>
        private void goToRegistrationCommand()
        {
            var currentRegion = _regionManager.Regions[_regionNameService.AuthFormRegion];
            var uri = new Uri(_viewModelNameService.RegisterViewString, UriKind.Relative);

            currentRegion.RequestNavigate(uri, (NavigationResult res) =>
            {
                var t = res;
            });
        }
        #endregion
    }
}
