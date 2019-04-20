using DryIoc;
using Prism.Regions;
using System;
using System.Windows.Controls;

namespace SelfTeacher.WinApp.Views.AuthView
{
    /// <summary>
    /// Interaction logic for AuthView
    /// </summary>
    public partial class AuthView : UserControl
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainer _dryIocContainer;

        public AuthView(
            IRegionManager regionManager,
            IContainer dryIocContainer)
        {
            InitializeComponent();
            this._regionManager = regionManager;
            this._dryIocContainer = dryIocContainer;

            if(_regionManager == null)
            {
                throw new ArgumentException(nameof(_regionManager));
            }
            _regionManager.RegisterViewWithRegion("AuthForm", typeof(AuthFormView));
            _regionManager.RegisterViewWithRegion("SocialButtons", typeof(SocialButtons));
        }
    }
}
