using CareManagment.Commands;
using CareManagment.Models;
using CareManagment.Tools;
using LiveCharts;
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

        public ICommand GetStatisticsCommand { get { return new GetStatisticsCommand(this); } }


        public StatisticsVM()
        {
            StatisticsM = new StatisticsM();

            Planned = new ObservableChartValues<int>(StatisticsM.Planned);
            Delivered = new ObservableChartValues<int>(StatisticsM.Delivered);
        }


        public void GetStatistics(int PreviousDays)
        {
            StatisticsM.GetStatistics(PreviousDays);
            Planned = new ObservableChartValues<int>(StatisticsM.Planned);
            Delivered = new ObservableChartValues<int>(StatisticsM.Delivered);
        }

    }
}
