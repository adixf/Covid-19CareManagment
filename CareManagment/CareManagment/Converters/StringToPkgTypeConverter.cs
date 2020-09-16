using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CareManagment.Converters
{
    class StringToPkgTypeConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
     
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string txt = ((ComboBoxItem)value).ToString();
            if (txt.Contains("תרופות"))
                return PkgType.תרופות;
            if (txt.Contains("ביגוד"))
                return PkgType.ביגוד;
            if (txt.Contains("משחקים"))
                return PkgType.משחקים;
            return PkgType.מזון;
           
        }
    }
}
