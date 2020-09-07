using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public Address Address { get; set; }

        public Person() { }
       
        public Person(string personId, string firstName, string lastName, string phoneNumber, string mailAddress, Address address)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            MailAddress = mailAddress;
            Address = address;
        }
    }
}
