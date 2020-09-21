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
    public class AdminDistributionsVM : DisplayDistributionsVM
    {
        public AdminDistributionsM AdminDistributionsM { get; set; }
    

        public AdminDistributionsVM()
        {
            AdminDistributionsM = new AdminDistributionsM();

            OldDistributions = new ObservableCollection<Distribution>(AdminDistributionsM.OldDistributions);
            NewDistributions = new ObservableCollection<Distribution>(AdminDistributionsM.NewDistributions);
            DistributionsToUpdate = new List<Distribution>();
           
        }


        
        public override void SaveChanges()
        {
            AdminDistributionsM.SaveChanges(DistributionsToUpdate);
            DistributionsToUpdate.Clear();

        }

       
    }
}
