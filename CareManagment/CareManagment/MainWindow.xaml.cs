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
           // var t=v.GetAddressDetails(new Address("בית שמש", "נחל רפאים", 11));
           //sol MessageBox.Show(t.Result.Description);

           /* v.AddDistribution(new Distribution(
                 new User("209425602", "נעמה", "שנברגר", "0545581921", "rachelibs1212@gmail.com", 
                 new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Volunteer), 
                 new List<Package>(), DateTime.Now.Date,
                 new User("209425602", "רחלי", "כהן", "0545581921", "x@gmail.com", 
                 new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Admin), false));

             v.AddDistribution(new Distribution(
       new User("209425602", "מרדכי", "אסולין", "0545581921", "rachelibs1277@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Volunteer), new List<Package>(), DateTime.Now.Date, new User("209425602", "שירה", "פוקס", "0545581921", "x123@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Admin), false));

             v.AddDistribution(new Distribution(
       new User("209425602", "יוסף", "גולד", "0545581921", "rachelibs12@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Volunteer), new List<Package>(), DateTime.Now.Date, new User("209425602", "יעקב", "אבינו", "0545581921", "x1234@gmail.com", new Address("bet Shemesh", "shemshon", 11), "1234567g", UserType.Admin), false));
         
         */
        }
     }
}

