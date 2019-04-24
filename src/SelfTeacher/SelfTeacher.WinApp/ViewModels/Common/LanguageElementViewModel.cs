using Prism.Mvvm;
using SelfTeacher.WinApp.Command.WpfCommand;
using SelfTeacher.WinApp.Domain.Service;
using SelfTeacherWinApp.Domain.Entities;
using System;
using System.Globalization;
using System.Windows.Input;

namespace SelfTeacher.WinApp.ViewModels.Common
{
    public class LanguageElementViewModel: BindableBase
    {
        #region Private members

        /// <summary>
        /// Localization service for chage all texts
        /// </summary>
        private readonly ILocalizationService _localizationService;

        private int _selectIndex;

        #endregion

        #region Public props
        public int SelectIndex
        {
            get
            {
                return _selectIndex;
            }
            set
            {
                SetProperty(ref _selectIndex, value);
            }
        }

        public ICommand LanguageChanged { get; set; }

        #endregion

        #region Constructor
        public LanguageElementViewModel(ILocalizationService localizationService)
        {
            this._localizationService = localizationService;


            //Localization set
            _localizationService.UICulture = new CultureInfo((int)ELanguage.Russian);
            _selectIndex = 0;

            LanguageChanged = new RelayCommand(() => languageChanged());
        }

        #endregion

        #region private events

        public void languageChanged()
        {
            _localizationService.UICulture = new CultureInfo(_selectIndex == 1 ? (int)ELanguage.English : (int)ELanguage.Russian );
        }

        #endregion
    }
}
