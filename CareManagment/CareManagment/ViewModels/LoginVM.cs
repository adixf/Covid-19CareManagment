using CareManagment.Commands;
using CareManagment.DP.Types;
using CareManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    public class LoginVM : BaseViewModel
    {       
        public LoginM CurrentModel { get; set; }

        #region commands
        public ICommand LoginCommand { get { return new LoginCommand(this); } }

        public ICommand DisplaySignUpView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new SignUpVM();});
            }
        }
        #endregion

        // properties bound to view
        public string Email { get; set; }
        public string Password { get; set; }

        
        public LoginVM()
        {
            CurrentModel = new LoginM();
        }

        // check if email and password describe an existing user
        public bool ValidUser(string email, string password)
        {
            return CurrentModel.ValidUser(email, password);
        }

        public void Login()
        {
            if (ValidUser(Email, Password))
            {
                ((App)Application.Current).Currents.LoggedUser = CurrentModel.GetUser(Email);
                if (((App)Application.Current).Currents.LoggedUser.UserType == UserType.Admin)
                    ((App)Application.Current).Currents.CurrentVM = new AdminMainVM();
                else
                    ((App)Application.Current).Currents.CurrentVM = new VolunteerMainVM();
            }
            else
            {
                Message = new Message("אופס!", "הפרטים שהזנת לא תואמים למשתמש קיים" + "\n" + "אנא נסה שנית", false, true);
                
            }
                
        }
    }
}
