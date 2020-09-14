using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
           
            Recipients = new List<Recipient>(BL.GetAllRecipients());
        }


        public List<Package>[] DividePackages(List<Package> Packages)
        {
            // k = number of distributions  = number of packages / packages per volunteer
            int K = (int)Math.Ceiling(Convert.ToDouble(Packages.Count) / ((App)Application.Current).Currents.MaxPackagesPerVolunteer);
            if (K > BL.GetAllVolunteers().Count)
                throw new Exception("מספר המתנדבים במערכת קטן מכדי לבצע את החלוקה כפי שביקשת");
            return BL.DividePackages(Packages, K);               
        }

        public User FindClosestVolunteer(Address address)
        {
            return BL.FindClosestVolunteer(address);
        }

        public void AddDistributions(List<Distribution> distributions)
        {
            BL.AddDistributions(distributions);
        }

    }
}
