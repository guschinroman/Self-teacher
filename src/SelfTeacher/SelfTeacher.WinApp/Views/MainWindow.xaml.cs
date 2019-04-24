using Prism.Regions;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacher.WinApp.Views.Common;
using SelfTeacherWinApp.Domain.Entities;
using System;
using System.Globalization;
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
            _regionManager = regionManager;
            if (_regionManager == null)
            {
                throw new ArgumentNullException(nameof(_regionManager));
            }
            _regionManager.RegisterViewWithRegion("LanguageChangeRegion", typeof(LanguageElementView));
            _regionManager.RegisterViewWithRegion("AuthRegion", typeof(AuthView.AuthView));
        }
    }
}
