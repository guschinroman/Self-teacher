using Prism.Mvvm;
using Prism.Regions;
using SelfTeacher.WinApp.Command.WpfCommand;
using SelfTeacher.WinApp.Domain.Services;
using SelfTeacher.WinApp.Domain.Services.Settings;
using System;
using System.Windows.Input;

namespace SelfTeacher.WinApp.ViewModels
{
    public class RegisterFormViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region Private fields
        private readonly IRegionManager _regionManager;
        private readonly IRegionNameService _regionNameService;
        private readonly IViewModelNameService _viewModelNameService;
        #endregion

        #region Public properties
        public bool KeepAlive => false;
        public ICommand GoToAuthPageCommand { get; }
        #endregion

        #region Constructor
        public RegisterFormViewModel(IRegionManager regionManager,
            IRegionNameService regionNameService,
            IViewModelNameService viewModelNameService)
        {
            GoToAuthPageCommand = new RelayCommand(goToAuthForm);
            this._regionManager = regionManager;
            this._regionNameService = regionNameService;
            this._viewModelNameService = viewModelNameService;
        }

        #endregion

        #region Public methods
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

        /// <summary>
        /// Method before make view deactive
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
        #endregion

        #region Private methods
        
        private void goToAuthForm()
        {
            var currentRegion = _regionManager.Regions[_regionNameService.AuthFormRegion];
            var uri = new Uri(_viewModelNameService.AuthFormViewString, UriKind.Relative);

            currentRegion.RequestNavigate(uri, (NavigationResult res) =>
            {
                var t = res;
            });
        }

        #endregion
    }
}
