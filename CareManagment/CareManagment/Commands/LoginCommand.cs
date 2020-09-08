
using CareManagment.DP;
using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CareManagment.Commands
{
    class LoginCommand : ICommand
    {
        // current vm using command
        public LoginVM CurrentVM { get; set; }

  
        public LoginCommand(LoginVM LoginVM)
        {
            CurrentVM = LoginVM;
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
            if (CurrentVM.ValidUser(CurrentVM.Email, CurrentVM.Password))
              {
                ((App)Application.Current).LoggedUser = CurrentVM.CurrentModel.BL.GetAllUsers(x => x.MailAddress == CurrentVM.Email).First();
              }
             else
                CurrentVM.ShowMessage = true;
             
        }
    }
}
