using System;
using System.Windows.Input;

namespace HuePlay
{
    internal delegate void ExecuteHandler(object parameter);
    internal delegate bool CanExecuteHandler(object parameter);

    internal class DelegateCommand : ICommand
    {
        private ExecuteHandler _executeHandler;
        private CanExecuteHandler _canExecuteHandler;

        public DelegateCommand(ExecuteHandler executeHandler) :
            this(executeHandler, CanAlwaysExecute)
        {
            // nothing
        }

        public DelegateCommand(ExecuteHandler executeHandler, CanExecuteHandler canExecuteHandler)
        {
            _executeHandler = executeHandler;
            _canExecuteHandler = canExecuteHandler;
        }

        public void RaiseCanExecuteChanged()
        {
            var eh = this.CanExecuteChanged;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteHandler(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeHandler(parameter);
        }

        private static bool CanAlwaysExecute(object parameter)
        {
            return true;
        }
    }
}
