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
    /// Interaction logic for DistributionDetailsUC.xaml
    /// </summary>
    public partial class DistributionDetailsUC : UserControl
    {
        public DistributionDetailsUC()
        {
            InitializeComponent();
            packagesList.ItemsSource = new List<int> { 8, 9, 0, 9, 8, 8, 0, 9, 0,1,1,1,1,1,1,1 };
        }
    }
}
