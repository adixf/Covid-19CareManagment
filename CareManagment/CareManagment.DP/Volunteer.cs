using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Volunteer : IUser
    {

        public int VolunteerId { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }

        public Volunteer() { }
        
        public Volunteer(string idNumber, string firstName, string lastName, string phoneNumber, string mailAddress, Address address, string password)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            MailAddress = mailAddress;
            Address = address;
            Password = password;

        }


        public Address GetAddress()
        {
            return Address;
        }

        public void SetAddress(double lat, double lon)
        {
            Address.Lat = lat;
            Address.Lon = lon;
        }

        public string GetMailAddress()
        {
            return MailAddress;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}
