using Prism.Mvvm;

namespace SelfTeacher.WinApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Self teacher";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
