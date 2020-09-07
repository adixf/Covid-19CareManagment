using CareManagment.DP;
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
    public partial class App : Application, INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        public App()
        { 
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
