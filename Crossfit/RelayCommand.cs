using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crossfit
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute = null;
        private Func<bool> methodToDetectCanExecute = null;

        public RelayCommand(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDetectCanExecute = methodToDetectCanExecute;
        }

        public RelayCommand(Action execute):
             this(execute, null)
        {
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.methodToDetectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDetectCanExecute();
            }
        }

        public void Execute(object parameter)
        {
            this.methodToExecute();
        }
    }
}
