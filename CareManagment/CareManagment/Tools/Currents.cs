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

        private IUser loggedUser;
        public IUser LoggedUser
        {
            get { return loggedUser; }
            set
            {
                loggedUser = value;
                OnPropertyRaised("LoggedUser");
            }
        }

        public int MaxPackagesPerVolunteer { get { return 8; } }
        public string MailAddress { get { return "covid19caremanagment@gmail.com"; } }
        public string MailPassword { get { return "covid19123"; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
