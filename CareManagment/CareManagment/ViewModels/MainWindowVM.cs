using CareManagment.Commands;
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
    class MainWindowVM : BaseViewModel
    {
       
        public MainWindowVM()
        {
            ((App)Application.Current).Currents.CurrentVM = new LoginVM();
        }
        
    }
}
