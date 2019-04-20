using SelfTeacher.WinApp.Domain.Services.Settings;

namespace SelfTeacher.WinApp.Services.Settings
{
    public class WinAppSettingsService : IWinAppSettingService
    {
        public ELanguage Language
        {
            get => Properties.Settings.Default.Language;
            set => Properties.Settings.Default.Language = value;
        }
    }
}
