using SelfTeacher.WinApp.Domain.Services;

namespace SelfTeacherWinApp.Infrastructure.Services
{
    public class RegionNameService : IRegionNameService
    {
        public string AuthRegion => "AuthRegion";

        public string LanguageChangeRegion => "LanguageChangeRegion";
    }
}
