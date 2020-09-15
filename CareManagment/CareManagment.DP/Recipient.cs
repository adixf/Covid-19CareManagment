using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Recipient :Person
    {
        //  public ICollection<Package> Packages { get; set; }

        public Recipient(string personId, string firstName, string lastName, string phoneNumber, string mailAddress, Address address):
            base(personId,firstName,lastName,phoneNumber,mailAddress,address)
        {
           
        }
        public Recipient()
        {

        }
    }
}



