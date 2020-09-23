using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.Models
{
     public class RecipientsViewM
     {
        public IBL BL { get; set; }

        public  List<Recipient> Recipients { get; set; }


        public RecipientsViewM()
        {
            BL = new BLImp();

            Recipients = new List<Recipient>(BL.GetAllRecipients());
        }

     }
}
