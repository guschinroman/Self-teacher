using SelfTeacher.WinApp.Domain.Services.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfTeacher.WinApp.Infrastructure.Services.Settings
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
