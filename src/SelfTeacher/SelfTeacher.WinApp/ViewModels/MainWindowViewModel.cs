using Prism.Mvvm;
using SelfTeacher.WinApp.Command.WpfCommand;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacher.WinApp.Services;
using SelfTeacherWinApp.Domain.Entities;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

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
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;


        /// <summary>
        /// The selected language on view
        /// </summary>
        public int Language { get; set; } = -1;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;



        public int ResizeBorder
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// the size of the border around the window? taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(ResizeBorder + OuterMarginSize);
            }
        }

        /// <summary>
        /// The padding content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

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
                return new Thickness(OuterMarginSize);
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

        /// <summary>
        /// Thr radius of the edges of the window
        /// </summary>
        public CornerRadius WindowsCornerRadius
        {
            get
            {
                return new CornerRadius(WindowsRadius);
            }
        }

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength
        {
            get
            {
                return new GridLength(TitleHeight);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The Maximize window Command
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The close windows command
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show menu
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region constructor
        public MainWindowViewModel()
        {
            _window = Application.Current.MainWindow;
            //Listen out for window resizing
            _window.StateChanged += (sender, e) =>
            {
                //fire off event for all properties tha are affected by a resize
                RaisePropertyChanged(nameof(ResizeBorderThickness));
                RaisePropertyChanged(nameof(OuterMarginSize));
                RaisePropertyChanged(nameof(OuterMarginSizeThickness));
                RaisePropertyChanged(nameof(WindowsRadius));
                RaisePropertyChanged(nameof(WindowsCornerRadius));

            };

            //Create command
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));
        }

        #endregion


        #region Private helpers
        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(_window);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }
        #endregion
    }
}
