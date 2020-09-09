using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using CareManagment.ViewModels;
using CareManagment.Views;
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
            /* v.AddDistribution(new Distribution(
                 new User("209425602", "r", "h", "0545581921", "rachelibs1212@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Volunteer), new List<Package>(), DateTime.Now, new User("209425602", "r", "h", "0545581921", "rachelibs12@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Admin), false));

             v.AddDistribution(new Distribution(
       new User("209425602", "r", "h", "0545581921", "rachelibs1277@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Volunteer), new List<Package>(), DateTime.Now, new User("209425602", "r", "h", "0545581921", "rachelibs12@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Admin), true));

             v.AddDistribution(new Distribution(
       new User("209425602", "r", "h", "0545581921", "rachelibs12@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Volunteer), new List<Package>(), DateTime.Now, new User("209425602", "r", "h", "0545581921", "rachelibs11112@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Admin), true));
         }*/
        }
    }
}
