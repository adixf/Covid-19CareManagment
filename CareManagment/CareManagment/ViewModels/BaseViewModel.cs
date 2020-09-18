using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.DP.Types;
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

        

        private Message message;
        public Message Message
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
