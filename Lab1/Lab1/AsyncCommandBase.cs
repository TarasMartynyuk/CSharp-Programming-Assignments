using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab1
{
    public abstract class AsyncCommandBase : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteImpl(parameter);
        }
 
        public async void Execute(object parameter)
        {
            await ExecuteImplAsync(parameter);
        }

        protected abstract Task ExecuteImplAsync(object o);
        protected abstract bool CanExecuteImpl(object o);
    }
}
