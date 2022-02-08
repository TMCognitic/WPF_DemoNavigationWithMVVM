using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Tools.Patterns.Mvvm.Commands
{
    public class Command : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add 
            { 
                CommandManager.RequerySuggested += value; 
            }
            remove 
            { 
                CommandManager.RequerySuggested -= value; 
            }
        }

        public Command(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); ;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
    public class Command<TParameter> : ICommand
    {
        private Action<TParameter> _execute;
        private Func<TParameter, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public Command(Action<TParameter> execute, Func<TParameter, bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); ;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((TParameter)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute((TParameter)parameter);
        }
    }
}
