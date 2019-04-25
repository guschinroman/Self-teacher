using System;
using System.Collections.Generic;
using System.Text;

namespace SelfTeacher.WinApp.Domain.Services
{
    public interface IRegionNameService
    {
        String AuthRegion { get; }
        String AuthFormRegion { get; }
        String LanguageChangeRegion { get; }
    }
}
