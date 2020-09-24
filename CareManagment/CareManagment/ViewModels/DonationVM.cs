using CareManagment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    public class DonationVM : BaseViewModel
    {
        private bool first;
        public bool First
        {
            get { return first; }
            set
            {
                first = value;
                OnPropertyRaised("First");
            }
        }

        private bool second;
        public bool Second
        {
            get { return second; }
            set
            {
                second = value;
                OnPropertyRaised("Second");
            }
        }

        public ICommand NextCommand { get { return new BaseCommand(delegate () { First = false; Second = true; }); } }

        public DonationVM()
        {
            First = true;
        }

    }
}
