using CareManagment.ViewModels;
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

namespace CareManagment.Views
{
    /// <summary>
    /// Interaction logic for AdminDistributionsUC.xaml
    /// </summary>
    public partial class AdminDistributionsUC : UserControl
    {
        public AdminDistributionsUC()
        {
            InitializeComponent();
            //List<int> lst = new List<int> { 1, 2, 7,9,9,9,9};
            //newDistributions.ItemsSource = lst;
            //List<int> lst2 = new List<int> { 1, 2, 3, 4 ,9,9,9,9,9,9,9,9,9};
            //oldDistributions.ItemsSource = lst2;
            DataContext = new AdminDistributionsVM();
        }
    }
}
