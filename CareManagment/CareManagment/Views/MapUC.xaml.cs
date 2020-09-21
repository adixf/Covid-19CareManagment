﻿using CareManagment.DP;
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
    /// Interaction logic for MapUC.xaml
    /// </summary>
    public partial class MapUC : UserControl
    {
        public List<Brush> colors = new List<Brush> { Brushes.Red, Brushes.DarkCyan, Brushes.Coral, Brushes.Violet, Brushes.Green };
        public int colorindex { get; set; }

        public MapUC()
        {
            InitializeComponent();
            Map.SetView(new Location(31.771959, 35.217018), 8);
        }

        public void SetMapLocation(Location location, int zoom) { Map.SetView(location, zoom); }
        public void SetMapLocation(Location location) { Map.SetView(location, 16); }
        public void Clear() { Map.Children.Clear(); }       
        public void AddAreas(List<Address> locations)
        {
            foreach (Address loc in locations)
            {
                Location pinLocation = new Location(loc.Lat, loc.Lon);
                ControlTemplate template = (ControlTemplate)this.FindResource("CustomPushpin");

                Pushpin pin = new Pushpin
                {
                    Foreground = colors[colorindex],
                    Template = template,
                    PositionOrigin = PositionOrigin.BottomLeft,
                    Location = pinLocation
                };
                
                Map.Children.Add(pin);
            }
            colorindex = (colorindex + 1) % colors.Count;
        }
    }
}
