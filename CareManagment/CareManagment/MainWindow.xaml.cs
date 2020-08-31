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
        private UserControl currentUC;
        public UserControl CurrentUC
        {
            get { return currentUC; }
            set
            {
                UserControlGrid.Children.Remove(currentUC);
                currentUC = value;
                UserControlGrid.Children.Add(currentUC);
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            CurrentUC = new LoginUC();
        }
    }
}
