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
    /// Interaction logic for DetailsPdfUC.xaml
    /// </summary>
    public partial class DetailsPdfUC : UserControl
    {
        public DetailsPdfUC()
        {
            InitializeComponent();
        }
        public void Print()
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(Details, "Distribution Details");
            }
                

        }
    }

}
