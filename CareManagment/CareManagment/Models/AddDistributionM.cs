using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using CareManagment.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CareManagment.Models
{
    class AddDistributionM
    {
        public List<Recipient> Recipients { get; set; }
        public List<Distribution> Distributions { get; set; }

        public IBL BL { get; set; }

        public AddDistributionM()
        {
            BL = new BLImp();
           
            Recipients = BL.GetAllRecipients();
        }


        public List<Package>[] DividePackages(List<Package> Packages)
        {
            // k = number of distributions  = number of packages / packages per volunteer
            int K = (int)Math.Ceiling(Convert.ToDouble(Packages.Count) / ((App)Application.Current).Currents.MaxPackagesPerVolunteer);
            if (K > BL.GetAllVolunteers().Count)
                throw new Exception("מספר המתנדבים במערכת קטן מכדי לבצע את החלוקה כפי שביקשת");
            return BL.DividePackages(Packages, K);               
        }

        public Volunteer FindClosestVolunteer(List<Volunteer> Volunteers, Address address)
        {
            return BL.FindClosestVolunteer(Volunteers, address);
        }

        public void AddDistributions(List<Distribution> distributions)
        {
            BL.AddDistributions(distributions);
            foreach (Distribution distribution in distributions)
                SendMail(BL.GetAllVolunteers(x => x.VolunteerId == distribution.VolunteerId).First());
        }

        public List<Volunteer> GetAllVolunteers()
        {
            return BL.GetAllVolunteers();
        }

        public void SendMail(Volunteer volunteer)
        {
            // send mail
            MailSender mailSender = new MailSender();
            string to = volunteer.MailAddress;
            string subject = "חלוקה חדשה";
            string body = "שלום " + volunteer.GetFirstName() + "," + "\n\n" + "נוספה לך חלוקה חדשה במערכת." + "\n\n" + "אנא היכנס למערכת לצפייה בפרטי החלוקה.";
            Thread thread = new Thread(() => mailSender.SendMail(to, subject, body));
            thread.Start();
        }

    }
}
