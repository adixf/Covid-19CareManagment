using CareManagment.Commands;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    class AdminMainVM : BaseViewModel
    {
        private BaseViewModel currentAdminVM;
        public BaseViewModel CurrentAdminVM
        {
            get { return currentAdminVM; }
            set
            {
                currentAdminVM = value;
                OnPropertyRaised("CurrentAdminVM");
            }
        }


        public AdminMainVM()
        {
            CurrentAdminVM = new AdminOptionsVM();
        }


        #region commands

        public ICommand DisplayDistributionsView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentAdminVM = new AdminDistributionsVM(); });
            }
        }

        public ICommand DisplayVolunteersView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentAdminVM = new VolunteersViewVM(); });
            }
        }

        public ICommand DisplayRecipientsView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentAdminVM = new RecipientsViewVM(); });
            }
        }

        public ICommand DisplayStatisticsView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentAdminVM = new StatisticsVM(); });
            }
        }

        public ICommand DisplayAddDistributionView
        {
            get
            {
                return new BaseCommand(delegate () { CurrentAdminVM = new AddDistributionVM();});
            }
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
      
        #endregion
    }
}
