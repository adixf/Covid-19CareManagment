using CareManagment.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    class MainWindowVM : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyRaised("CurrentViewModel");             
            }
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
                return new BaseCommand(delegate () { CurrentViewModel = new ContactUsVM(); });
            }
        }
        public ICommand DisplayAboutUsView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentViewModel = new AboutUsVM(); });
            }
        }
        public ICommand DisplayDonationView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentViewModel = new DonationVM(); });
            }
        }
        public ICommand DisplayLoginView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentViewModel = new LoginVM(); });
            }
        }
        public ICommand DisplaySignUpView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentViewModel = new SignUpVM(); });
            }
        }
        #endregion

        public MainWindowVM()
        {
            CurrentViewModel = new LoginVM();
        }
        
    }
}
