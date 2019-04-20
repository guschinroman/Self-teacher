using System;
using System.Windows.Input;

namespace SelfTeacher.WinApp.Command.WpfCommand
{
    public class RelayCommand : ICommand
    {
        #region private member

        private Action _execute;
        private Func<object, bool> _canExecute;

        #endregion

        #region public events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region constructor

        public RelayCommand(Action execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion


        public bool CanExecute(object parameter)
        {
            return this._canExecute == null || this._canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
