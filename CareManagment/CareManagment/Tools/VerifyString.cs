using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CareManagment.Tools
{
    public class VerifyString
    {
        public bool IsVaildEmail(string emailaddress)
        {
            if (emailaddress.Length < 1)
                return false;
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool IsValidPersonId(string id)
        {
            {
                
                if (id == null || !int.TryParse(id, out int x) || id.Length != 9)
                {  // Make sure ID is formatted properly
                    return false;
                }
                int incNum, sum = 0;
                for(int i=0; i<9; i++)
                {
                    incNum = int.Parse(id[i].ToString()) * ((i % 2) + 1);  // Multiply number by 1 or 2
                    sum += (incNum > 9) ? incNum - 9 : incNum;  // Sum the digits up and add to total
                }
                return sum % 10 == 0;
            }
        }

        public bool IsValidPhoneNumber(string number)
        {
            return Regex.IsMatch(number,@"^(\+972|972|0)(5\d|\d)\d{7}$");
        }

        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        public bool IsValidPassword(string password)
        {
            return password.Length == 8;
        }
    }
}
