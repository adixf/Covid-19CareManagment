using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.Models
{
    public class SignUpM
    {
        public IBL BL { get; set; }

        public SignUpM()
        {
            BL = new BLImp();
        }

        public void SignUp(User user)
        {
            // BL.AddPerson();
        }
    }
}
