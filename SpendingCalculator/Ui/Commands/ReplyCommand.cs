using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SpendingCalculator.Ui.Commands
{
    class ReplyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = delegate { };
        
        private readonly Action<object> execute;

        private readonly Predicate<object> canExecute;

        public ReplyCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            execute.Invoke(parameter);
        }
    }
}
