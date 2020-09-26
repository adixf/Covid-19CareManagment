using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.DP.Types;
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
using System.Windows.Threading;

namespace CareManagment.ViewModels
{
    class AddDistributionVM : DisplayDistributionsVM
    {
        public AddDistributionM AddDistributionM { get; set; }

        public DateTime DistributionDate { get; set; }

        private ObservableCollection<Recipient> recipients;
        public ObservableCollection<Recipient> Recipients
        {
            get
            { return recipients; }
            set
            {
                recipients = value;
                Packages = new ObservableCollection<Package>();
                foreach (Recipient recipient in recipients)
                    Packages.Add(new Package()
                    {
                        Contents = PkgType.מזון, // initial package type
                        Recipient = recipient
                    });
                OnPropertyRaised("Recipients");
            }
        }

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

        private ObservableCollection<Distribution> distributions;
        public ObservableCollection<Distribution> Distributions
        {
            get { return distributions; }
            set
            {
                distributions = value;
                OnPropertyRaised("Distributions");
            }
        }

        public ObservableCollection<string> Cities { get; set; }

        private string selectedCity;
        public string SelectedCity
        {
            get { return selectedCity; }
            set
            {
                // update recipients according to selected city
                selectedCity = value;
                var all = new ObservableCollection<Recipient>(AddDistributionM.Recipients);
                if (selectedCity == "כל הארץ")
                    Recipients = all;
                else Recipients = new ObservableCollection<Recipient>(all.Where(r => r.Address.City.Equals(selectedCity)));
                OnPropertyRaised("SelectedCity");
            }
        }

        private bool isDistributionReady;
        public bool IsDistributionReady
        {
            get { return isDistributionReady; }
            set
            {
                isDistributionReady = value;

                OnPropertyRaised("IsDistributionReady");
            }
        }

        private bool isWorking;
        public bool IsWorking
        {
            get { return isWorking; }
            set
            {
                isWorking = value;
                OnPropertyRaised("IsWorking");
            }
        }

        public ICommand CreateDistributionsCommand { get { return new CreateDistributionsCommand(this); } }

        public MapUC AreasMap { get; set; }


        public AddDistributionVM()
        {
            AddDistributionM = new AddDistributionM();
            Recipients = new ObservableCollection<Recipient>(AddDistributionM.Recipients);

            DistributionDate = DateTime.Now.Date;

            GetAllCities();
            SelectedCity = Cities.First(x => x.Equals("כל הארץ"));

            AreasMap = new MapUC();
        }


        private void GetAllCities()
        {
            // add all cities from recipients to Cities
            Cities = new ObservableCollection<string>();
            foreach (Recipient r in AddDistributionM.Recipients)
            {
                if (!Cities.Contains(r.Address.City))
                    Cities.Add(r.Address.City);
            }
            Cities.Add("כל הארץ");
        }

        public void CreateDistributions()
        {
            try
            {              
                Distributions = new ObservableCollection<Distribution>();

                // divide packages into distributions
                List<Package>[] DividedPackages = AddDistributionM.DividePackages(Packages.ToList());

                Application.Current.Dispatcher.BeginInvoke(
                    new Action(() => { AddDistributions(DividedPackages); }));

                // show areas on map
                Application.Current.Dispatcher.BeginInvoke(
                   new Action(() => { ShowAreasOnMap(); }));

                //  add to database             
                Application.Current.Dispatcher.BeginInvoke(
                   new Action(() => { AddDistributionM.AddDistributions(new List<Distribution>(Distributions)); }));

                IsDistributionReady = true;

                // finish
                Recipients = new ObservableCollection<Recipient>(AddDistributionM.Recipients);
                

            }

            catch (Exception e)
            {
                Message = new Message("משהו השתבש.", e.Message, false, true);
            }
        }

        private void ShowAreasOnMap()
        {

            AreasMap.Clear();
            Location location = new Location();
            if (selectedCity != "כל הארץ")
            {
                try
                {
                    // re-center map
                    location.Latitude = Distributions[0].Packages[0].Recipient.Address.Lat;
                    location.Longitude = Distributions[0].Packages[0].Recipient.Address.Lon;
                    AreasMap.SetMapLocation(location, 9);
                }
                catch { }
            }
            else AreasMap.SetMapLocation(new Location(32.032527, 34.8851379), 8);
                       
            List<Address> Addresses = new List<Address>();
            foreach (Distribution distribution in Distributions.ToList())
            {
                foreach (Package p in distribution.Packages.ToList())
                {
                    Addresses.Add(p.Recipient.Address);
                }

                AreasMap.AddAreas(Addresses);
                Addresses.Clear();
            }
            SelectedCity = "כל הארץ";
        }

        private void AddDistributions(List<Package>[] DividedPackages)
        {
            try
            {
                foreach (var pkgGroup in DividedPackages)
                {
                    Distributions.Add(new Distribution()
                    {
                        Date = DistributionDate,
                        Packages = pkgGroup,
                        AdminId = (((App)Application.Current).Currents.LoggedUser as Admin).AdminId
                    });
                }
                
                AssignVolunteers();
                
            }
            catch (Exception e)
            {
                Message = new Message("משהו השתבש.", e.Message, false, true);
            }

        }

        private void AssignVolunteers()
        {
            // find closest volunteer for each distribution
            List<Volunteer> volunteers = new List<Volunteer>(AddDistributionM.GetAllVolunteers());
            foreach (Distribution d in Distributions)
            {
                Volunteer closestVolunteer = AddDistributionM.FindClosestVolunteer(volunteers, d.Packages[0].Recipient.Address);
                d.VolunteerId = closestVolunteer.VolunteerId;
                volunteers.Remove(closestVolunteer);
            }
        }

    }
}
