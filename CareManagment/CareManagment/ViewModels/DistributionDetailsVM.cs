using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.Models;
using CareManagment.Views;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    public class DistributionDetailsVM : BaseViewModel
    {
        public DistributionDetailsM DistributionDetailsM { get; set; }

        public Distribution CurrentDistribution { get; set; }

        private ObservableCollection<Package> packages;
        public ObservableCollection<Package> Packages
        {
            get { return packages; }
            set
            {
                packages = value;
                OnPropertyRaised("Packages");
            }
        }

        public MapUC MapView { get; set; }

        public ICommand DisplayLocationCommand { get { return new DisplayLocationCommand(this); } }

        private Location location;
        public Location Location
        {
            get { return location; }
            set
            {
                location = value;
                MapView.SetMapLocation(location);
                OnPropertyRaised("Location");
            }
        }


        public DistributionDetailsVM(int distributionId)
        {
            MapView = new MapUC();
            DistributionDetailsM = new DistributionDetailsM();

            CurrentDistribution = DistributionDetailsM.GetDistribution(distributionId);
            Packages = new ObservableCollection<Package>(DistributionDetailsM.GetAllPackages(distributionId));
        }
        
    }
}
