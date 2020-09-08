using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareManagment.BL.Interfaces;
using CareManagment.BL;
using System.Collections.ObjectModel;
using CareManagment.DP;

namespace CareManagment.Models
{
    public class LoginM
    {
        public IBL BL { get; set; }

        public ObservableCollection<User> Users { get; set; }

        public LoginM()
        {
            BL= new BLImp();
            Users = new ObservableCollection<User>(BL.GetAllUsers());
        }

        public bool ValidUser(string email, string password)
        {
            foreach (var user in Users)
                if (user.MailAddress == email && user.Password == password)
                    return true;
            return false;
        }

        public User GetUser(string email)
        {
            return Users.First(x => x.MailAddress == email);
        }
    }

}
