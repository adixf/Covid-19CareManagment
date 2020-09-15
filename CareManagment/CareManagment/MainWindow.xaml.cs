using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using CareManagment.Tools;
using CareManagment.ViewModels;
using CareManagment.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CareManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
           
            DataContext = new MainWindowVM();
            var v = new BL.BLImp();
            // var t=v.GetAddressDetails(new Address("בית שמש", "נחל רפאים", 11));
            //sol MessageBox.Show(t.Result.Description);

           // v.DeletePerson(v.GetAllPersons(x => x.MailAddress == "TL@gmail.com").First());

          
        }
     }
}

