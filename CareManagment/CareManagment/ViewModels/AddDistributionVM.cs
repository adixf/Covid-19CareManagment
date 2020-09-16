using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.Models;
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
    class AddDistributionVM : BaseViewModel
    {
        public AddDistributionM AddDistributionM { get; set; }

        public DateTime DistributionDate { get; set; }
        private ObservableCollection<Recipient> recipients;
        public ObservableCollection<Recipient> Recipients
        {
            get
            {
                return recipients;
            }
            set
            {               
                recipients = value;
                OnPropertyRaised("Recipients");
            }
        }

        public List<Package> Packages { get; set; }
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
        public ICommand AcceptDistributionsCommand
        {
            get
            {
                return new BaseCommand(delegate () { AddDistributionM.AddDistributions(new List<Distribution>(Distributions)); });
            }
        }

        public AddDistributionVM()
        {
            AddDistributionM = new AddDistributionM();

            Recipients = new ObservableCollection<Recipient>(AddDistributionM.Recipients);
            Distributions = new ObservableCollection<Distribution>();
            Packages = new List<Package>();
            DistributionDate = DateTime.Now.Date;
           
            GetAllCities();
            SelectedCity = Cities.First(x=> x.Equals("כל הארץ"));
        }

        private void GetAllCities()
        {
            // add all cities from recipients to Cities
            Cities = new ObservableCollection<string>();
            foreach(Recipient r in AddDistributionM.Recipients)
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
                foreach (Recipient recipient in Recipients)
                    Packages.Add(new Package()
                    {
                        Contents = PkgType.מזון, // TODO fix type
                        Recipient = recipient
                    });

                // divide packages into distributions
                List<Package>[] DividedPackages = AddDistributionM.DividePackages(Packages);

                Application.Current.Dispatcher.BeginInvoke(
                    new Action(() => { AddDistributions(DividedPackages); }));

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                // TODO open dialog
            }
        }

        private void AddDistributions(List<Package>[] DividedPackages)
        {
            foreach (var pkgGroup in DividedPackages)
            {
                Distributions.Add(new Distribution()
                {
                    Date = DistributionDate,
                    Packages = pkgGroup,
                    Admin = ((App)Application.Current).Currents.LoggedUser as Admin
                });
            }

            AssignVolunteers();

        }

        private void AssignVolunteers()
        {
            // find closest volunteer for each distribution
            List<Volunteer> volunteers = new List<Volunteer>(AddDistributionM.GetAllVolunteers());
            foreach (Distribution d in Distributions)
            {
                Volunteer closestVolunteer = AddDistributionM.FindClosestVolunteer(volunteers, d.Packages[0].Recipient.Address);
                d.Volunteer = closestVolunteer;
                volunteers.Remove(closestVolunteer);
            }
        }
    }
}
