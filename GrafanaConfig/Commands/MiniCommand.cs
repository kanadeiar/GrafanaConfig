using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafanaConfig.Commands
{
    /// <summary> Мини команды WPF </summary>
    public class MiniCommand : CommandBase
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;
        public MiniCommand() { }
        public MiniCommand(Action execute) : this(execute, null) { }
        public MiniCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute();
        }
        public override void Execute(object parameter)
        {
            this.execute();
        }
    }
    /// <summary> Обобщенные команды WPF </summary>
    /// <typeparam name="T">тип</typeparam>
    public class MiniCommand<T> : CommandBase
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;
        public MiniCommand() { }
        public MiniCommand(Action<T> execute) : this(execute, null) { }
        public MiniCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute((T)parameter);
        }
        public override void Execute(object parameter)
        {
            this.execute((T)parameter);
        }
    }
}
