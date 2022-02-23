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
    /// Userinfo_newInputPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Userinfo_newInputPage : Page
    {
        public Userinfo_newInputPage()
        {
            InitializeComponent();
        }
        private void UserNameTbox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Equals("Type your name"))
            {
                tb.Text = "";
            }
        }
        private void UserNameTbox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Equals(""))
            {
                tb.Text = "Type your name";
            }
            foreach(char c in tb.Text)
            {
                if (c >= '0' && c <= '9' || c==' ')
                {
                    tb.Text = "Type your name";
                    break;
                }
            }

        }

        private void UserBirthTbox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text.Equals("Type your Birthday in 8-numbers"))
            {
                tb.Text = "";
            }
        }
        private void UserBirthTbox_LostFocus(object sender, RoutedEventArgs e)
        {
            int birthday;
            var tb = (TextBox)sender;
            if (tb.Text.Equals(""))
            {
                tb.Text = "Type your Birthday in 8-numbers";
            }
            else if (tb.Text.Length == 8 && int.TryParse(tb.Text, out birthday))
            {
                // 1999 11 23
                int Year, Month, Day;
                int nowYear = DateTime.Now.Year;
                Year = int.Parse(tb.Text.Substring(0, 4));
                Month = int.Parse(tb.Text.Substring(4, 2));
                Day = int.Parse(tb.Text.Substring(6, 2));

                if (Year > nowYear || Year < 1900)
                {
                    MessageBox.Show("Invalid Year");
                    tb.Text = "Type your Birthday in 8-numbers";
                }
                else if (Month > 12 || Month < 1)
                {
                    MessageBox.Show("Invalid Month");
                    tb.Text = "Type your Birthday in 8-numbers";
                }
                else if (Day > 31 || Day < 1)
                {
                    MessageBox.Show("Invalid Day");
                    tb.Text = "Type your Birthday in 8-numbers";
                }

            }// 생년월일이 유효한지 확인
            else
            {
                tb.Text = "Type your Birthday in 8-numbers";
            }
        }

        private void UserHeightTbox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if(tb.Text== "Type your Height (cm)")
            {
                tb.Text = "";
            }
        }
        private void UserHeightTbox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!double.TryParse(tb.Text, out double a))
            {
                tb.Text = "Type your Height (cm)";
            }
        }

        private void UserWeightTbox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == "Type your Weight (kg)")
            {
                tb.Text = "";
            }
        }
        private void UserWeightTbox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!double.TryParse(tb.Text, out double a))
            {
                tb.Text = "Type your Weight (kg)";
            }
        }

        private void UserGoalTbox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (tb.Text == "Type your Goal Weight (kg)")
            {
                tb.Text = "";
            }
        }
        private void UserGoalTbox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            if (!double.TryParse(tb.Text, out double a))
            {
                tb.Text = "Type your Goal Weight (kg)";
            }
        }
    }
}
