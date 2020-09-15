using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.Commands
{
    class AddPackageCommand : ICommand
    {
        public AddDistributionVM CurrentVM { get; set; }

        public AddPackageCommand(AddDistributionVM vm)
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
            string Id = ((object[])parameter)[0].ToString();
            string Type = ((object[])parameter)[1].ToString();
            CurrentVM.AddPackage(Id, Type);
        }
    }
}
