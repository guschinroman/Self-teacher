using System;
using System.Globalization;

namespace ServiceTeacher.Service.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception for inner application problem
    /// </summary>
    public class AppException: Exception
    {
        #region constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public AppException(): base() { }
        /// <summary>
        /// String ctor
        /// </summary>
        /// <param name="message"></param>
        public AppException(string message): base(message) { }
        /// <summary>
        /// Extended ctor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
        #endregion
    }
}
