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
    public class SignUpCommand : ICommand
    {
        public ISignUp CurrentVM { get; set; }

        public SignUpCommand(ISignUp SignUpVM)
        {
            CurrentVM = SignUpVM;
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
            CurrentVM.SignUp();
        }
    }
}
