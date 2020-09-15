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
        public ObservableCollection<Recipient> Recipients { get; set; }
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

        public ICommand AddPackageCommand { get { return new AddPackageCommand(this); } }
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
            DistributionDate = DateTime.Now.Date;
            Recipients = new ObservableCollection<Recipient>(AddDistributionM.Recipients);
            Packages = new List<Package>();
            IsDistributionReady = false;
            Distributions = new ObservableCollection<Distribution>();
        }

        public void AddPackage(string MailAddress, String Type)
        {
            Recipient recipient = Recipients.First(x => x.MailAddress == MailAddress);
            Package package = Packages.Find(x => x.Recipient == recipient);

            if (package != null)
            {
                Packages.Remove(package);
            }
            else
            {
                Enum.TryParse(Type, out PkgType pkgType);
                Package Package = new Package()
                {
                    Recipient = recipient,
                    Contents = pkgType
                };
                Packages.Add(Package);
            }

        }

        public void CreateDistributions()
        {
            try
            {
                // divide packages into distributions
                List<Package>[] DividedPackages = AddDistributionM.DividePackages(Packages);

                Application.Current.Dispatcher.BeginInvoke(
                    new Action(() => { AddDistributions(DividedPackages); }));

            }
            catch (Exception e)
            {
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
                    Packages = new List<Package>(pkgGroup),
                    Admin = ((App)Application.Current).Currents.LoggedUser
                });
            }

            // find closest volunteer for each distribution
            foreach (Distribution d in Distributions)
            {
                d.Volunteer = AddDistributionM.FindClosestVolunteer(d.Packages[0].Recipient.Address);
            }

        }
    }
}
