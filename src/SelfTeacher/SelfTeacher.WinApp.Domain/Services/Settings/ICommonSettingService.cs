using SelfTeacherWinApp.Domain.Entities;

namespace SelfTeacher.WinApp.Domain.Services.Settings
{
    public interface IWinAppSettingService
    {
        ELanguage Language { get; set; }
    }
}
