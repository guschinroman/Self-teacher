namespace SelfTeacher.WinApp.Domain.Services.Settings
{
    public interface IViewModelNameService
    {
        string MainWindowViewString { get; }

        string LanguageElementViewString { get; }

        string AuthFormViewString { get; }

        string AuthViewString { get; }

        string RegisterViewString { get; }

        string SocialButtonViewString { get; }
    }
}
