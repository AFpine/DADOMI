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

namespace DADOMI.View.Pages
{
    /// <summary>
    /// ExercisePage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ActivityPage : Page
    {
        public ActivityPage()
        {
            InitializeComponent();
        }

        private void minuteTb_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            tb.Text = "";
        }

        private void minuteTb_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == ""||tb.Text==null) tb.Text = "운동 시간";
            else if (!double.TryParse(tb.Text, out double a)) tb.Text = "운동 시간";
        }
    }
}
