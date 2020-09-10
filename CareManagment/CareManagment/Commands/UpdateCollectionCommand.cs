using CareManagment.Interfaces;
using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.Commands
{
    class UpdateCollectionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public IUpdateCollection CurrentVM { get; set; }

        public UpdateCollectionCommand(IUpdateCollection vm)
        {
            CurrentVM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          CurrentVM.CollectionChanged(parameter);
        }
    }
}
