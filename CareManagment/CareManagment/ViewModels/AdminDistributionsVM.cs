using CareManagment.DP;
using CareManagment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.ViewModels
{
    class AdminDistributionsVM : BaseViewModel
    {
        public AdminDistributionsM AdminDistributionsM { get; set; }

        public ObservableCollection<Distribution> NewDistributions
        {
            get
            {
                return new ObservableCollection<Distribution>(AdminDistributionsM.NewDistributions);
            }
            set
            {
                AdminDistributionsM.NewDistributions = new List<Distribution>(value);
            }
        }

        public ObservableCollection<Distribution> OldDistributions
        {
            get
            {
                return new ObservableCollection<Distribution>(AdminDistributionsM.OldDistributions);
            }
            set
            {
                AdminDistributionsM.OldDistributions = new List<Distribution>(value);
            }
        }

        public AdminDistributionsVM()
        {
            AdminDistributionsM = new AdminDistributionsM();

            OldDistributions = new ObservableCollection<Distribution>(AdminDistributionsM.OldDistributions);
            NewDistributions = new ObservableCollection<Distribution>(AdminDistributionsM.NewDistributions);
        }
    }
}
