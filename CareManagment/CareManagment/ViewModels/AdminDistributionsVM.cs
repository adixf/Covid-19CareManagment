using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.Interfaces;
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
    public class AdminDistributionsVM : BaseViewModel, IUpdateCollection
    {
        public AdminDistributionsM AdminDistributionsM { get; set; }

        public List<Distribution> DistributionsToUpdate { set; get; }

        public ObservableCollection<Distribution> NewDistributions { get; set; }

        public ObservableCollection<Distribution> OldDistributions
        {
            get;
            set;
        }
        

        public ICommand UpdateCollection { get { return new UpdateCollectionCommand(this); } }
        public ICommand SaveChangesCommand { get { return new SaveChangesCommand(this); } }


        public AdminDistributionsVM()
        {
            AdminDistributionsM = new AdminDistributionsM();

            OldDistributions = new ObservableCollection<Distribution>(AdminDistributionsM.OldDistributions);
            NewDistributions = new ObservableCollection<Distribution>(AdminDistributionsM.NewDistributions);
            DistributionsToUpdate = new List<Distribution>();
           
        }


        public void CollectionChanged(Object o)
        {
            int Id = int.Parse(o.ToString());
            List<Distribution> AllDistributions = new List<Distribution>(OldDistributions);
            AllDistributions.AddRange(NewDistributions);
            Distribution distribution = AllDistributions.Find(x => x.DistributionId == Id);
            DistributionsToUpdate.Add(distribution);
            if (distribution.IsDelivered)
            {
                NewDistributions.Remove(distribution);
                OldDistributions.Add(distribution);
            }
            else 
            {
                NewDistributions.Add(distribution);
                OldDistributions.Remove(distribution);

            }
        }
        public void SaveChanges()
        {
            AdminDistributionsM.SaveChanges(DistributionsToUpdate);
            DistributionsToUpdate.Clear();

        }
    }
}
