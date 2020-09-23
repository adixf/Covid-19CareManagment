using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.Tools
{
    public class ObservableChartValues<T> : ChartValues<T>, INotifyCollectionChanged
    {
        public ObservableChartValues() { }
        public ObservableChartValues(IEnumerable<T> IEnumerable) : base(IEnumerable) { }

    }
}
