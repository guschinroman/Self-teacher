using System;
using System.Globalization;

namespace SelfTeacher.WinApp.Domain.Service
{
    public interface ILocalizationService
    {
        event Action<CultureInfo> UICultureChanged;

        CultureInfo UICulture { get; set; }

        string Get(string dictionary, string key, params object[] args);

        bool HasKey(string dictionary, string key);
    }
}
