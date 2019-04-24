using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SelfTeacher.WinApp.ValueConverters
{
    /// <summary>
    /// A base value converter that allows direct XAML usage
    /// </summary>
    /// <typeparam name="T"> The type of this value converter</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        #region Private member
        /// <summary>
        /// A single static instance of this value converter
        /// </summary>
        private static T _converter = null;

        #endregion

        #region Markup extancion methiods
        /// <summary>
        /// Provides a static instance of the valie converter
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        #endregion

        #region Value converter methods

        /// <summary>
        /// The methods to conver one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// The method to conver a value back to it's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
