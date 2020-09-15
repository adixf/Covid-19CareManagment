using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.Commands
{
    public class DonationCommand : ICommand
    {

        public DonationVM CurrentVM { set; get; }
        public DonationCommand(DonationVM vm)
        {
            CurrentVM = vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "אחר")
                CurrentVM.TotalSumTextBox = "Visible";
            else
            CurrentVM.TotalSumText = parameter.ToString()+" סך כל התרומה";
        }
    }
}
