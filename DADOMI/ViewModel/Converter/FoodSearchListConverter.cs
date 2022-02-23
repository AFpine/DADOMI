using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Globalization;
using DADOMI.Model;
using DADOMI.View.UserControls;

namespace DADOMI.ViewModel.Converter
{
    public class FoodSearchListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FoodSearchListControl FSLC;
            IList<Row> foodlist = (IList<Row>)value;
            IList<FoodSearchListControl> flist = new List<FoodSearchListControl>();
            if (foodlist != null)
            {
                if (foodlist.Count != 0)
                {
                    for (int i = 0; i < foodlist.Count; i++)
                    {
                        FSLC = new FoodSearchListControl();
                        FSLC.FSLC_name.Text = foodlist[i].FOOD_NAME;
                        FSLC.FSLC_maker.Text = foodlist[i].FOOD_MAKER;
                        flist.Add(FSLC);
                    }
                    return flist;
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
