﻿using System;
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

namespace CareManagment.Views
{
    /// <summary>
    /// Interaction logic for VolunteerMain.xaml
    /// </summary>
    public partial class VolunteerMainUC : UserControl
    {
        private UserControl currentUC;
        public UserControl CurrentUC
        {
            get { return currentUC; }
            set
            {
                // switch user control
                UserControlGrid.Children.Remove(currentUC);
                currentUC = value;
                UserControlGrid.Children.Add(currentUC);

            }
        }

        public VolunteerMainUC()
        {
            InitializeComponent();

            CurrentUC = new VolunteerDistributionsUC();
        }

    }
}