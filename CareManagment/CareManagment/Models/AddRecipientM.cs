using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;

namespace CareManagment.Models
{
    class AddRecipientM
    {
        public IBL BL { get; set; }


        public AddRecipientM()
        {
            BL = new BLImp();
        }


        public void SignUp(Recipient recipient)
        {
            if (new Tools.VerifyString().ArePropertiesNull<Recipient>(recipient))
                throw new Exception("אנא מלא את כל השדות");
            if (BL.GetAllRecipients(x => x.MailAddress == recipient.MailAddress).Count != 0)
                throw new Exception("המשתמש כבר קיים במערכת");
            if (!new Tools.VerifyAddress().IsValidAddress(recipient.Address))
                throw new Exception("הכתובת שהזנת לא קיימת");
            double[] location = new Tools.VerifyAddress().GetLocation(recipient.Address);
            recipient.Address.Lat = location[0];
            recipient.Address.Lon = location[1];
            BL.AddRecipient(recipient);
        }
    }
}
