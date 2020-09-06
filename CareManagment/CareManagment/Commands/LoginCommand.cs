
using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
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


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (!(parameter is List<string> details))
                return false;

            if (details.Count != 2)
                return false;

            string email = details[0];
            string password = details[1];

            if (password.Length == 0) return false;

            MailAddress mailAddress;
            try
            {
                mailAddress = new MailAddress(email);
            }
            catch (Exception)
            {
                return false;
            }           
            return true;
        }

        public void Execute(object parameter)
        {
            var userLogin = parameter as List<string>;
            // if (CurrentVM.ValidUser(userLogin[0], userLogin[1]))
        }
    }
}
