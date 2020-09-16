using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Distribution 
    {

        public int DistributionId { get; set; }

        private Volunteer volunteer;
        public Volunteer Volunteer
        {
            get { return volunteer; }
            set
            {
                volunteer = value;
                if(value!=null)
                    VolunteerId = volunteer.VolunteerId;
            }
        }

        public int VolunteerId { get; set; }

        private Admin admin;
        public Admin Admin
        {
            get { return admin; }
            set
            {
                admin = value;
                if(value!=null)
                    AdminId = admin.AdminId;
            }
        }
        public int AdminId { get; set; }

        public List<Package> Packages { get; set; }
        public DateTime Date { get; set; }

        public bool IsDelivered { get; set; }
        
      
        public Distribution(Volunteer volunteer, List<Package> packages, DateTime date, Volunteer admin, bool isDelivered)
        {
            Admin = new Admin(admin.IdNumber,admin.FirstName,admin.LastName,admin.PhoneNumber,admin.MailAddress,admin.Address,admin.Password);
            Packages = new List<Package>();
            Volunteer = new Volunteer(volunteer.IdNumber, volunteer.FirstName, volunteer.LastName, volunteer.PhoneNumber, volunteer.MailAddress, volunteer.Address, volunteer.Password);
            Date = date;
            IsDelivered = isDelivered;
        }

        public Distribution() { }
    }
}
