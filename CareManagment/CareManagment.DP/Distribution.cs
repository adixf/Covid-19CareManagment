using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Distribution
    {

        public int Id { get; set; }
        public User Volunteer { get; set; }
        public List<Package> Packages { get; set; }
        public DateTime Date { get; set; }
        public User Admin { get; set; }
        public bool IsDelivered { get; set; }
        public Distribution(User volunteer, List<Package> packages, DateTime date, User admin, bool isDelivered)
        {
            Admin = new User(admin.PersonId,admin.FirstName,admin.LastName,admin.PhoneNumber,admin.MailAddress,admin.Address,admin.Password,admin.UserType);
            Packages = new List<Package>();
            Volunteer = new User(volunteer.PersonId, volunteer.FirstName, volunteer.LastName, volunteer.PhoneNumber, volunteer.MailAddress, volunteer.Address, volunteer.Password, volunteer.UserType);
           // Volunteer = volunteer;
            Packages = packages;
            Date = date;
            //Admin = admin;
            IsDelivered = isDelivered;
        }
        public Distribution()
        {

        }
    }
}
