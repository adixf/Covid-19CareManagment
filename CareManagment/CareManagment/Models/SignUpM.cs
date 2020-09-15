using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using CareManagment.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            if (new Tools.VerifyString().ArePropertiesNull<User>(user))
                throw new Exception("אנא מלא את כל השדות");
            if (BL.GetAllUsers(x => x.MailAddress == user.MailAddress).Count != 0)
                throw new Exception("המשתמש כבר קיים במערכת");
            /*if (!new Tools.VerifyAddress().IsValidAddress(user.Address))
                throw new Exception("הכתובת שהזנת לא קיימת");*/
            BL.AddPerson(user);
            MailSender mailSender = new MailSender();
            string to = user.MailAddress;
            string subject = "ברוך הבא לעמותת יד ביד";
            string body = 
                string.Format("לכבוד {0} ההרשמה נקלטה במערכת בהצלחה\n"+" {1}:הסיסמה למערכת היא", user.FirstName,user.Password);
            Thread thread = new Thread(() => mailSender.SendMail(to, subject, body));
            thread.Start();
        }

        
    }
}
