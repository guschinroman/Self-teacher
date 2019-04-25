using Prism.Mvvm;
using Prism.Regions;
using SelfTeacher.WinApp.Domain.Services;
using SelfTeacher.WinApp.Views.AuthView;

namespace SelfTeacher.WinApp.ViewModels
{
    public class AuthViewViewModel : BindableBase, INavigationAware, IRegionMemberLifetime
    {
        #region Public properties
        public bool KeepAlive => false;
        #endregion

        #region constructor
        public AuthViewViewModel()
        {

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
    }
}
