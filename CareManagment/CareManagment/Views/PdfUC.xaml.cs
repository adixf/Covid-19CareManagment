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
using System.Windows.Shapes;

namespace CareManagment.Views
{
    /// <summary>
    /// Interaction logic for PdfUC.xaml
    /// </summary>
    public partial class PdfUC : Window
    {
        public PdfUC()
        {
            InitializeComponent();
            DataContext = new PdfVM();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            PrintDialog pdf = new PrintDialog();
            if (pdf.ShowDialog() == true)
            {
                pdf.PrintVisual(babe,"file");
            }
        }
    }
}
