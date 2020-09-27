using CareManagment.BL;
using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.Models;
using CareManagment.Tools;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    class StatisticsVM : BaseViewModel
    {
        public StatisticsM StatisticsM { get; set; }

        private ObservableChartValues<int> planned;
        public ObservableChartValues<int> Planned
        {
            get { return planned; }
            set
            {
                planned = value;
                OnPropertyRaised("Planned");
            }
        }

        private ObservableChartValues<int> delivered;
        public ObservableChartValues<int> Delivered
        {
            get { return delivered; }
            set
            {
                delivered = value;
                OnPropertyRaised("Delivered");
            }
        }

        private SeriesCollection pieChartSeries;
        public SeriesCollection PieChartSeries
        {            
            get { return pieChartSeries; }
            set
            {
                pieChartSeries = value;
                OnPropertyRaised("PieChartSeries");
            }
        }
        
        public ICommand GetStatisticsCommand { get { return new GetStatisticsCommand(this); } }


        public StatisticsVM()
        {
            StatisticsM = new StatisticsM();

            Planned = new ObservableChartValues<int>(StatisticsM.Planned);
            Delivered = new ObservableChartValues<int>(StatisticsM.Delivered);
            AddCities();
        }

        public void GetStatistics(int PreviousDays)
        {
            StatisticsM.GetStatistics(PreviousDays);
            Planned = new ObservableChartValues<int>(StatisticsM.Planned);
            Delivered = new ObservableChartValues<int>(StatisticsM.Delivered);
            AddCities();
        }


        private List<string> GetAllCities()
        {
            // add all cities from recipients to Cities
            List<string> Cities = new List<string>();

            foreach (Package p in StatisticsM.CurrentPackages)
                if (!Cities.Contains(p.Recipient.Address.City))
                    Cities.Add(p.Recipient.Address.City);

            return Cities;
        }

        private int CountInCity(string City)
        {
            int count = 0;

            foreach (Package p in StatisticsM.CurrentPackages)
                if (p.Recipient.Address.City.Equals(City))
                    count++;

            return count;
        }

        public void AddCities()
        {
            string labelPoint(ChartPoint chartPoint) =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            List<string> Cities = GetAllCities();
            PieChartSeries = new SeriesCollection();
            foreach (string city in Cities)
            {
                int numOfDistributions = CountInCity(city);
                PieChartSeries.Add(
                new PieSeries
                {
                    Title = city,
                    Values = new ObservableChartValues<double> { numOfDistributions },
                    PushOut = 2,
                    DataLabels = true,
                    LabelPoint = labelPoint
                });

            }
        }

    }
}
