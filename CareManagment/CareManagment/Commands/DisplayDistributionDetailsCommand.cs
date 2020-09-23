
using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.Commands
{
    class DisplayDistributionDetailsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DisplayDistributionsVM CurrentVM { get; set; }

        public DisplayDistributionDetailsCommand(DisplayDistributionsVM VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int.TryParse(parameter.ToString(), out int Id);
            CurrentVM.DisplayDetails(Id);
        }
    }
}
