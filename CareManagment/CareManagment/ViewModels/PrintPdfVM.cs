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
    public class PrintPdfVM : BaseViewModel
    {
        public PrintPdfM PrintPdfM { get; set; }

        public ObservableCollection<Package> Packages { get; set; }

        private Volunteer volunteer;
        public Volunteer Volunteer
        {
            get { return volunteer; }
            set
            {
                volunteer = value;
                OnPropertyRaised("Volunteer");
            }
        }
        private Distribution distribution;
        public Distribution Distribution
        {
            get { return distribution; }
            set
            {
                distribution = value;
                OnPropertyRaised("Distribution");
            }
        }


        public PrintPdfVM(int DistributionId)
        {
            PrintPdfM = new PrintPdfM(DistributionId);

            Distribution = PrintPdfM.Distribution;
            Packages = new ObservableCollection<Package>(PrintPdfM.Packages);
            Volunteer = PrintPdfM.Volunteer;
        }
    }
}
