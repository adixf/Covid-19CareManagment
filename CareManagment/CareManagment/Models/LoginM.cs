using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareManagment.BL.Interfaces;
using CareManagment.BL;

namespace CareManagment.Models
{
    public class LoginM
    {
        public IBL BL { get; set; }

        public LoginM()
        {
            BL= new BLImp();
        }

        public bool ValidUser(string email, string password)
        {
            return BL.ValidUser(email, password);
        }
    }

}
