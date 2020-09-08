using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareManagment.BL.Interfaces;
using CareManagment.BL;
using CareManagment.DP;

namespace CareManagment.Models
{
    public class LoginM
    {
        public IBL BL { get; set; }
        public List<User> users { get; set; }

        public LoginM()
        {
            BL= new BLImp();
            users = new List<User>();
            users = BL.GetAllUsers();
        }

        public bool ValidUser(string email, string password)
        {
            foreach (var v in users)
                if (v.MailAddress == email && v.Password == password)
                    return true;
            return false;
            //return BL.ValidUser(email, password);
        }
    }

}
