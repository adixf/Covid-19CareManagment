using CareManagment.DP;
using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CareManagment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, System.ComponentModel.INotifyPropertyChanged
    {
        public void OnPropertyRaised(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public User LoggedUser { get; set; }
        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel { get { return currentViewModel; }
            set { currentViewModel = value;
                OnPropertyRaised("CurrentViewModel"); } }
        public App()
        {
            CurrentViewModel = new LoginVM();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
