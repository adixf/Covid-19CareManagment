using CareManagment.Commands;
using CareManagment.Interfaces;
using CareManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    public class LoginVM : ILoginVM
    {       
        public LoginM CurrentModel { get; set; }

        public ICommand LoginCommand { get { return new LoginCommand(this); } }

        // properties binded to view
        public string Email { get; set; }
        public string Password { get; set; }

        // ctor
        public LoginVM()
        {
            CurrentModel = new LoginM();
        }

        // check if email and password describe an existing user
        public bool ValidUser(string email, string password)
        {
            //return CurrentModel.
            return true;
        }
    }
}
