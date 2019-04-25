using SelfTeacher.WinApp.Domain.Services.Settings;

namespace SelfTeacherWinApp.Infrastructure.Services
{
    public class ViewModelNameService : IViewModelNameService
    {
        public string MainWindowViewString => "MainWindowView";

        public string LanguageElementViewString => "LanguageElementView";

        public string AuthFormViewString => "AuthFormView";

        public string AuthViewString => "AuthView";

        public string RegisterViewString => "RegisterFormView";

        public string SocialButtonViewString => "SocialButtonsView";
    }
}
