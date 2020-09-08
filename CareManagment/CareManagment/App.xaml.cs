using CareManagment.DP;
using CareManagment.Tools;
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
    public partial class App : Application
    { 
       public Currents Currents { get; set; }
        
        public App()
        {
            Currents = new Currents();
        }        
    }
}
