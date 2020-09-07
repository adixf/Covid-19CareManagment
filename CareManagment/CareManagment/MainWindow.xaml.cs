using CareManagment.BL;
using CareManagment.BL.Interfaces;
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
            //IBL v = new BLImp();
           // var t = v.GetAllUsers();
              // foreach (var ele in t)
              //  MessageBox.Show(ele.FirstName);
           // v.AddPerson(new DP.User("209425602", "hahaha", "fgf", "0546867152", "nana@gmail.com", new DP.Address("bet ", "hgh", 1),"209425602",UserType.Volunteer));

        }
    }
}
