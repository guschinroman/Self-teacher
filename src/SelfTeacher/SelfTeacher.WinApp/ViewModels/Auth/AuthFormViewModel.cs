using Prism.Mvvm;

namespace SelfTeacher.WinApp.ViewModels
{
    public class AuthFormViewModel : BindableBase
    {
        #region Private member

        #endregion

        #region Public Properties

        public string Test { get; set; } = "My string";

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public AuthFormViewModel()
        {
            
        }
        #endregion
    }
}
