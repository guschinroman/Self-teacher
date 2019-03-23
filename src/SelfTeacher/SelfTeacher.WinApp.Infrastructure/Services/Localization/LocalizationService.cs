using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacher.WinApp.Domain.Services.Localization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace SelfTeacher.WinApp.Domain.Services
{
    public abstract class LocalizationService : ILocalizationService
    {
        private CultureInfo _uiCulture;
        private readonly ILogger _logger;
        private readonly ICommonSettingsService _settingsService;
        private readonly Dictionary<int, Dictionary<string, ResourceDictionary>> _dictionaries;

        public event Action<CultureInfo> UICultureChanged;

        public int RuCulture
        {
            get => (int)ELanguage.Russian;
        }

        public int EnCulture
        {
            get => (int)ELanguage.English;
        }

        protected LocalizationService(ICommonSettingsService settingService, ILogger logger)
        {
            _settingsService = settingService;
            _logger = logger;
            try
            {
                _uiCulture = new CultureInfo((int)_settingsService.Language);
            }
            catch (Exception)
            {
                _uiCulture = CultureInfo.InstalledUICulture;
            }
            _dictionaries = new Dictionary<int, Dictionary<string, ResourceDictionary>>
            {
                {(int) ELanguage.Russian, new Dictionary<string, ResourceDictionary>()},
                {(int) ELanguage.English, new Dictionary<string, ResourceDictionary>()}
            };
        }

        public abstract void Initialize();

        public CultureInfo UICulture
        {
            get { return _uiCulture; }
            set
            {
                if (_uiCulture != value)
                {
                    _uiCulture = value;
                    _uiCulture = value;
                    Thread.CurrentThread.CurrentUICulture = value;
                    Thread.CurrentThread.CurrentCulture = value;
                    ResxExtension.UpdateAllTargets();

                    if (UICultureChanged != null)
                        UICultureChanged(_uiCulture);
                }
            }
        }

        public string Get(string dictionary, string key, params object[] args)
        {
            ResourceDictionary targetDictionary;
            if (!_dictionaries[_uiCulture.LCID].TryGetValue(dictionary, out targetDictionary))
            {
                _logger.Error("Try get not exists localization string: {0} - {1}", dictionary, key);
                return string.Format("{0}.{1}", dictionary, key);
            }

            if (!targetDictionary.ContainsKey(key))
            {
                _logger.Error("Try get not exists localization string: {0} - {1}", dictionary, key);
                if (!targetDictionary.ContainsKey(dictionary + key))
                {
                    _logger.Error("Try get not exists localization string: {0} - {1}", dictionary, dictionary + key);
                    return string.Format("{0}.{1}", dictionary, key);
                }
                return string.Format((string)targetDictionary[dictionary + key], args);
            }

            return string.Format((string)targetDictionary[key], args);
        }

        public bool HasKey(string dictionary, string key)
        {
            ResourceDictionary targetDictionary;
            if (!_dictionaries[_uiCulture.LCID].TryGetValue(dictionary, out targetDictionary))
                return false;

            return targetDictionary.ContainsKey(key);
        }

        protected void LoadDictionary(int culture, string key, string file)
        {
            try
            {
                var uri = new Uri(Path.Combine("/Resources/", file), UriKind.Relative);

                var dictionary = new ResourceDictionary
                {
                    Source = uri
                };

                _dictionaries[culture].Add(key, dictionary);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Cannot load localization dictionary: {0} - {1}", key, file);
            }
        }

        protected void AddCustom(int culture, string dictionary, string key, string value)
        {
            try
            {
                _dictionaries[culture][dictionary].Add(key, value);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Failed to add dictionary value: {0} - {1} - {2}", dictionary, key, value);
            }

        }
    }
}
