using DADOMI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DADOMI.ViewModel.Converter
{
    class ActivitySelectListConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> actlist = new List<string>();
            ObservableCollection<ActivityRow> actcollect = (ObservableCollection<ActivityRow>)value;
            for(int i = 0;i<actcollect.Count;i++)
            {
                actlist.Add(actcollect[i].ActivityName);
            }
            return actlist;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
