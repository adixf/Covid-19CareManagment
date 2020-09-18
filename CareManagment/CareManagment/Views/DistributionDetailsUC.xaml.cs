using CareManagment.ViewModels;
using Microsoft.Maps.MapControl.WPF;
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

            Map.SetView(new Location(31.771959, 35.217018), 12);
        }

        public void SetMapLocation(Location location) { Map.SetView(location, 16); }
    }
}
