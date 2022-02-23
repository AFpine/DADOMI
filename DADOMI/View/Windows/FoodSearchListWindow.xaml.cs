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

namespace DADOMI.View.Windows
{
    /// <summary>
    /// FoodSearchListWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FoodSearchListWindow : Window
    {
        public FoodSearchListWindow()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Equals("섭취량"))
            {
                tb.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Equals(""))
            {
                tb.Text = "섭취량";
            }
        }
    }
}