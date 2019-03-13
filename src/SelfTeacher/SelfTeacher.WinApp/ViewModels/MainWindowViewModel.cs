using Prism.Mvvm;

namespace SelfTeacher.WinApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Self teacher";
        private string _name = "";
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

        public MainWindowViewModel()
        {

        }
    }
}
