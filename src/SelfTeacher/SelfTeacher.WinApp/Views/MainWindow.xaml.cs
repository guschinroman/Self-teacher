using SelfTeacher.WinApp.Domain.Services;
using System.Windows;

namespace SelfTeacher.WinApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IInitManager _initManager;

        public MainWindow(IInitManager initManager)
        {
            InitializeComponent();
            _initManager = initManager;

            _initManager.InitRegions();
        }
    }
}
