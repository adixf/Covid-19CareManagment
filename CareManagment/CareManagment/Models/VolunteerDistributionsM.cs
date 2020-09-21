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
    class VolunteerDistributionsM
    {
        public IBL BL { get; set; }

        public List<Distribution> OldDistributions { get; set; }

        public List<Distribution> NewDistributions { get; set; }

        public VolunteerDistributionsM()
        {
            BL = new BLImp();

            OldDistributions = new List<Distribution>(BL.GetAllDistributions(x => (x.Volunteer.MailAddress == ((App)Application.Current).Currents.LoggedUser.GetMailAddress()) && x.IsDelivered).ToList());
            NewDistributions = new List<Distribution>(BL.GetAllDistributions(x => (x.Volunteer.MailAddress == ((App)Application.Current).Currents.LoggedUser.GetMailAddress()) && !x.IsDelivered).ToList());

        }

        public void SaveChanges(List<Distribution> distributions)
        {
            foreach (var element in distributions)
                BL.UpdateDistribution(element);

        }
    }
}
