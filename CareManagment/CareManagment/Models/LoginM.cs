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

        public List<Volunteer> Volunteers { get; set; }
        public List<Admin> Admins { get; set; }

        public LoginM()
        {
            BL= new BLImp();
            Volunteers = BL.GetAllVolunteers();
            Admins = BL.GetAllAdmins();
        }

        public bool ValidUser(string email, string password)
        {
            foreach (var user in Volunteers)
                if (user.MailAddress == email && user.Password == password)
                    return true;
            foreach (var user in Admins)
                if (user.MailAddress == email && user.Password == password)
                    return true;
            return false;
        }

        public IUser GetUser(string email)
        {
            foreach (var user in Volunteers)
                if (user.MailAddress == email)
                    return user;
            foreach (var user in Admins)
                if (user.MailAddress == email)
                    return user;
            return Admins.First();
        }
    }

}
