using Prism.Mvvm;
using System.Windows;

namespace SelfTeacher.WinApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Private properties
        private string _title = "Self teacher";
        private string _name = "";
        private Window _window;

        /// <summary>
        /// The margin in from to allow for drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// Thr radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region Public Properties
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(ResizeBorder);
            }
        }

        /// <summary>
        /// The margin in from to allow for drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin in from to allow for drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(ResizeBorder);
            }
        }

        /// <summary>
        /// Thr radius of the edges of the window
        /// </summary>
        public int WindowsRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        #endregion

        #region constructor
        public MainWindowViewModel()
        {
            _window = Application.Current.MainWindow;
            //Listen out for window resizing
            _window.StateChanged += (sender, e) =>
            {

            };
        }
        #endregion
    }
}
