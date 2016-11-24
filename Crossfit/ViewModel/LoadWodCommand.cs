using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crossfit.ViewModel
{
    public class LoadWodCommand : ICommand
    {
        private readonly Action execute;

        public LoadWodCommand(Action execute)
        {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
