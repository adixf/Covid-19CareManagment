using CareManagment.DP;
using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for VolunteersViewUC.xaml
    /// </summary>
    public partial class VolunteersViewUC : UserControl
    {
        public VolunteersViewUC()
        {
            InitializeComponent();
            DataContext = new VolunteersViewVM();
        }
    }
}
