using CareManagment.DP;
using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.Tools
{

    /// <summary>
    /// class for keeping current application-wide properties
    /// </summary>
    public class Currents : INotifyPropertyChanged
    {
        private BaseViewModel currentVM;
        public BaseViewModel CurrentVM
        {
            get { return currentVM; }
            set
            {
                currentVM = value;
                OnPropertyRaised("CurrentVM");
            }
        }
        private User loggedUser;
        public User LoggedUser
        {
            get { return loggedUser; }
            set
            {
                loggedUser = value;
                OnPropertyRaised("LoggedUser");
            }
        }

        public int MaxPackagesPerVolunteer { get { return 3; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
