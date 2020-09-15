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
            Address adr1 = new Address("בית שמש", "נחל שמשון", 4)
            {
                Lat = 31.713400,
                Lon = 36.000351 
            };
            Address adr2 = new Address("בית שמש", "נחל שחם", 4)
            {

                Lat = 31.813400,
                Lon = 35.000351
            };
            Address adr3 = new Address("בית שמש", "נחל דולב", 4)
            {

                Lat = 31.713400,
                Lon = 35.000351
            };
            Address adr4 = new Address("ירושלים", "בית הדפוס", 4)
            {

                Lat = 61.713400,
                Lon = 45.000351
            };
            Address adr5 = new Address("ירושלים", "הקבלן", 4)
            {

                Lat = 61.713400,
                Lon = 45.800351
            };
            //v.AddPerson(new Recipient("21222222", "אריאל", "בש", "0545581921", "q@gmail.com@", adr1));
            //v.AddPerson(new Recipient("20100000", "אורה", "בש", "0545581921", "q@gmail.com@", adr2));
            //v.AddPerson(new Recipient("20000100", "אורי", "בש", "0545581921", "q@gmail.com@", adr3));
            //v.AddPerson(new Recipient("21000000", "אברהם", "ירוש", "0545581921", "q@gmail.com@", adr4));
            //v.AddPerson(new Recipient("20900000", "אליהו", "ירוש", "0545581921", "q@gmail.com@", adr5));
            //v.AddPerson(new Recipient("20200000", "אמיתי", "ירוש", "0545581921", "q@gmail.com@", new Address("ירושלים", "בית הדפוס", 11)));
            //v.AddPerson(new Recipient("20004000", "אליענה", "כפס", "0545581921", "q@gmail.com@", new Address("כפר סבא", "ויצמן", 4)));
            //v.AddPerson(new Recipient("20000060", "ארמדיל", "כפס", "0545581921", "q@gmail.com@", new Address("כפר סבא", "ויצמן", 8)));

            //v.AddPerson(new User("23000060", "מתי", "בש", "0545581921", "q@gmail.com@", new Address("בית שמש", "נחל דולב", 2), "00000000", UserType.Volunteer));
            //v.AddPerson(new User("23300060", "מורי", "כפס", "0545581921", "q@gmail.com@", new Address("כפר סבא", "ויצמן", 8), "00000000", UserType.Volunteer));
            //v.AddPerson(new User("23330060", "מרים", "אלת", "0545581921", "q@gmail.com@", new Address("אילת", "ארגמן", 8), "00000000", UserType.Volunteer));
            //v.AddPerson(new User("33300060", "מתילדה", "אלת", "0545581921", "q@gmail.com@", new Address("אילת", "ארגמן", 2), "00000000", UserType.Volunteer));
            //v.AddPerson(new User("20000333", "מקסים", "ירוש", "0545581921", "q@gmail.com@", new Address("ירושלים", "בית הדפוס", 9), "00000000", UserType.Volunteer));

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

