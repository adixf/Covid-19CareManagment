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
        public IBL BLImp { get; set; }

        public LoginM()
        {
            BLImp = new BLImp();
        }

        public bool ValidUser(string email, string password)
        {
            return BLImp.ValidUser(email, password);
        }
    }

}
