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
        private User _volunteer;
        public User Volunteer
        {
            get { return _volunteer; }
            set { _volunteer = value; VolunterrId = _volunteer.Id; }
        }
        private User _admin;
        public User Admin
        {
            get { return _admin; }
            set { _admin = value; AdminId = _admin.Id; }
        }
        public int VolunterrId { get; set; }
        public List<Package> Packages { get; set; }
        public DateTime Date { get; set; }
        public int AdminId { get; set; }
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
