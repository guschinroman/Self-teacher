using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SelfTeacher.WinApp.PE;
using System.Windows;

namespace SelfTeacher.WinApp.ViewModels
{
    public class AuthFormViewModel : BindableBase
    {
        #region Private member

        private readonly IRegionManager _regionManager;
        #endregion

        #region Public Properties

        public LoginPe LoginPe { get; set; }

        public DelegateCommand GoToRegistrationCommand { get; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public AuthFormViewModel(IRegionManager regionManager)
        {
            GoToRegistrationCommand = new DelegateCommand(goToRegistrationCommand);
            _regionManager = regionManager;
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void goToRegistrationCommand()
        {
            _regionManager.RequestNavigate()
        }


        #endregion
    }
}
