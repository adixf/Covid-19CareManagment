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
        public int PersonId { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public MailAddress MailAddress { get; set; }
        public Address Address { get; set; }
    }
}
