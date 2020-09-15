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
        
        public ICommand DonationCommand { get { return new DonationCommand(this); } }
        private string text;
        public string TotalSumText
        {
            get { return text; }
            set { text = value;
                OnPropertyRaised("TotalSumText"); }
        }
        private string textBox;
        public string TotalSumTextBox
        {
            get { return textBox; }
            set
            {
                textBox = value;
                OnPropertyRaised("TotalSumTextBox");
            }
        }


    }
}
