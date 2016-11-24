using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Crossfit.ViewModel
{
    public class SaveWodCommand : ICommand
    {
        private readonly Action execute;

        public SaveWodCommand(Action execute)
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
