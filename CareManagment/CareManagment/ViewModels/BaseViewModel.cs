using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private bool showMessage;
         public bool ShowMessage { get { return showMessage; }
            set { showMessage = value;
                OnPropertyRaised("ShowMessage");  } }
        
    }
}
