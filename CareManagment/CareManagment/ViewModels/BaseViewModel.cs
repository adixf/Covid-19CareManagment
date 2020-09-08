using CareManagment.Commands;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public BaseViewModel()
        {
            ShowMessage = false;
        }

        #region commands 
        /// <summary>
        /// commands
        /// </summary>
        /// 
        public ICommand DisplayContactUsView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new ContactUsVM(); });
            }
        }
        public ICommand DisplayAboutUsView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new AboutUsVM(); });
            }
        }
        public ICommand DisplayDonationView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new DonationVM(); });
            }
        }
        public ICommand DisplayLoginView
        {
            get
            {
                return new BaseCommand(delegate () { ((App)Application.Current).Currents.CurrentVM = new LoginVM(); });
            }
        }

        #endregion

        private bool showMessage;
        public bool ShowMessage
        {
            get { return showMessage; }
            set
            {
                showMessage = value;
                OnPropertyRaised("ShowMessage");
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyRaised("Message");
            }
        }

    }
}
