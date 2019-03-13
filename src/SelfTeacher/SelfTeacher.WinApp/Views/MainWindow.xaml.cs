using Prism.Regions;
using System;
using System.Windows;

namespace SelfTeacher.WinApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager _regionManager;

        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            this._regionManager = regionManager;

            if(_regionManager == null)
            {
                throw new ArgumentNullException(nameof(_regionManager));
            }
            _regionManager.RegisterViewWithRegion("AuthRegion", typeof(AuthView.AuthView));
        }
    }
}
