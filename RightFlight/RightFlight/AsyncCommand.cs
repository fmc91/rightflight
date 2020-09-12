using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RightFlight
{
    public class AsyncCommand<T> : ICommand
    {
        private Func<T, Task> ExecuteDelegate;

        private Predicate<T> CanExecuteDelegate;

        public event EventHandler CanExecuteChanged;

        public AsyncCommand(Func<T, Task> executeDelegate, Predicate<T> canExecuteDelegate)
        {
            if (executeDelegate == null || canExecuteDelegate == null)
                throw new ArgumentNullException();

            ExecuteDelegate = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
        }

        public AsyncCommand(Func<T, Task> executeDelegate) : this(executeDelegate, x => true) { }

        public bool CanExecute(object parameter)
        {
            return CanExecuteDelegate((T)parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteDelegate((T)parameter);
        }
    }
}
