using System;
using System.Windows.Input;

namespace GrafanaConfig.Commands
{
    /// <summary>
    /// Базовая команда
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
