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
using CareManagment.DP;
using CareManagment.ViewModels;

namespace CareManagment.Views
{
    /// <summary>
    /// Interaction logic for VolunteerMain.xaml
    /// </summary>
    public partial class VolunteerMainUC : UserControl
    {
        

        public VolunteerMainUC()
        {
            InitializeComponent();

            DataContext = new VolunteerMainVM();
        }

    }
}
