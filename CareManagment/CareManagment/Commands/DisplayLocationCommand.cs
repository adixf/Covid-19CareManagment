using CareManagment.DP;
using CareManagment.ViewModels;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.Commands
{
    class DisplayLocationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DistributionDetailsVM CurrentVM { get; set; }

        public DisplayLocationCommand(DistributionDetailsVM VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Address address = parameter as Address;
            CurrentVM.Location = new Location(address.Lat, address.Lon);
        }
    }
}
