using CareManagment.Commands;
using CareManagment.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Input;

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

        public ICommand SignOut
        {
            get
            {
                return new BaseCommand(delegate ()
                {
                    ((App)Application.Current).Currents.LoggedUser = null;
                    ((App)Application.Current).Currents.CurrentVM = new LoginVM();
                });
            }
        }
    }
}
