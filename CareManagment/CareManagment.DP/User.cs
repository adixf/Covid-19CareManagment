using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class User : Person
    {
        public User() { }
        
        public User(string personId, string firstName, string lastName, string phoneNumber, string mailAddress, Address address, string password, UserType userType) :base(personId, firstName,lastName, phoneNumber, mailAddress, address)
        {
            Password = password;
            UserType = userType;
        }

        public string Password { get; set; }
        public UserType UserType { set; get; }
    }
}
