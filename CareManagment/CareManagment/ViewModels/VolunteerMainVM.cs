using CareManagment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.ViewModels
{
    class VolunteerMainVM : BaseViewModel
    {
        private BaseViewModel currentVolunteerVM;
        public BaseViewModel CurrentVolunteerVM
        {
            get { return currentVolunteerVM; }
            set
            {
                currentVolunteerVM = value;
                OnPropertyRaised("CurrentVolunteerVM");
            }
        }

        public VolunteerMainVM()
        {
            CurrentVolunteerVM = new VolunteerDistributionsVM();
        }
    }
}
