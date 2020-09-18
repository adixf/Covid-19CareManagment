using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.DP.Types;
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
                Packages = new ObservableCollection<Package>();
                foreach(Recipient recipient in recipients)
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
        public ICommand AcceptDistributionsCommand
        {
            get
            {
                return new BaseCommand(delegate () { AcceptDistributions(); });
            }
        }


        // Distribution Details Managment
        private DistributionDetailsVM currentDetailsDisplay;
        public DistributionDetailsVM CurrentDetailsDisplay
        {
            get { return currentDetailsDisplay; }
            set
            {
                currentDetailsDisplay = value;
                OnPropertyRaised("CurrentDetailsDisplay");
            }
        }

        private bool isDisplayingDetails;
        public bool IsDisplayingDetails
        {
            get { return isDisplayingDetails; }
            set
            {
                isDisplayingDetails = value;
                OnPropertyRaised("IsDisplayingDetails");
            }
        }

        public ICommand DisplayDetailsCommand { get { return new DisplayDistributionDetailsCommand(this); } }

        public void DisplayDetails(int Id)
        {
            CurrentDetailsDisplay = new DistributionDetailsVM(Id);
            IsDisplayingDetails = true;
        }


        public AddDistributionVM()
        {
            AddDistributionM = new AddDistributionM();
            Recipients = new ObservableCollection<Recipient>(AddDistributionM.Recipients);                     

            Distributions = new ObservableCollection<Distribution>();
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
                // divide packages into distributions
                List<Package>[] DividedPackages = AddDistributionM.DividePackages(Packages.ToList());

                Application.Current.Dispatcher.BeginInvoke(
                    new Action(() => { AddDistributions(DividedPackages); }));

                Application.Current.Dispatcher.BeginInvoke(
                    new Action(() => { AddDistributionM.AddDistributions(new List<Distribution>(Distributions)); }));

            }
            catch (Exception e)
            {
                Message = new Message("משהו השתבש.", e.Message, false, true);
            }
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

        private void AcceptDistributions()
        {
            try
            {
                // start over
                Recipients = new ObservableCollection<Recipient>(AddDistributionM.Recipients);
                Distributions = new ObservableCollection<Distribution>();
            }
            catch (Exception e)
            {
                Message = new Message("משהו השתבש.", e.Message, false, true);
            }
           
        }

    }
}
