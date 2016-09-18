using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DragAndDropSample.Commands
{
    public class DelegateCommand : ICommand
    {
        private Action _action;
        private bool _canExecute;

        public DelegateCommand(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}
