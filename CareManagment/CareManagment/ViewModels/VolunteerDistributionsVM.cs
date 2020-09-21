using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    class VolunteerDistributionsVM : DisplayDistributionsVM
    {
        public VolunteerDistributionsM VolunteerDistributionsM { get; set; }


        public VolunteerDistributionsVM()
        {
            VolunteerDistributionsM = new VolunteerDistributionsM();

            OldDistributions = new ObservableCollection<Distribution>(VolunteerDistributionsM.OldDistributions);
            NewDistributions = new ObservableCollection<Distribution>(VolunteerDistributionsM.NewDistributions);
            DistributionsToUpdate = new List<Distribution>();

        }

       
        public override void SaveChanges()
        {
            VolunteerDistributionsM.SaveChanges(DistributionsToUpdate);
            DistributionsToUpdate.Clear();

        }
    }
}
