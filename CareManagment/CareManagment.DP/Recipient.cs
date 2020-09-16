using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Recipient
    {
        public int RecipientId { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public Address Address { get; set; }

        public Recipient() { }

        public Recipient(string idNumber, string firstName, string lastName, string phoneNumber, string mailAddress, Address address)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            MailAddress = mailAddress;
            Address = address;
        }
    }
}



