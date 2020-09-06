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
    /// Interaction logic for VolunteerDistributionsUC.xaml
    /// </summary>
    public partial class VolunteerDistributionsVM : UserControl
    {
        public VolunteerDistributionsVM()
        {
            InitializeComponent();
            // List<Distribution> distributions = new List<Distribution>();
            List<int> lst = new List<int> { 1, 2 };
            newDistributions.ItemsSource = lst;
            List<int> lst2 = new List<int> { 1, 2, 3, 4 };
            oldDistributions.ItemsSource = lst2;
        }


    }
}
