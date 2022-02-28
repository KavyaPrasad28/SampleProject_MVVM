using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleProject_MVVM.Commands
{
    public class MyCommands : ICommand
    {
        private Action _targetMethod;
        private Func<bool> _canExecuteTarget;
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
        public MyCommands(Action target, Func<bool> permitted)
        {
            this._targetMethod = target;
            this._canExecuteTarget = permitted;
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecuteTarget != null)
            {
                return this._canExecuteTarget();
            }
            return false;
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(null))
            {
                return;
            }
            if (_targetMethod != null)
            {
                _targetMethod();
            }
        }
    }
}
