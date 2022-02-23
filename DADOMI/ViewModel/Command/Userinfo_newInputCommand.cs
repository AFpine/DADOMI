using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class Userinfo_newInputCommand : ICommand
    {

        public UserVM Us;
        public Userinfo_newInputCommand(UserVM u)
        {
            Us = u;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //0 UserNameTbox
            //1 UserBirthTbox
            //2 UserHeightTbox
            //3 UserWeightTbox
            //4 UserGoalTbox
            //5 UserSexRadBtn_Male
            var values = (object[])parameter;
            if (values.Length == 8)
            {
                var name = (System.Windows.Controls.TextBox)values[0];
                var birth = (System.Windows.Controls.TextBox)values[1];
                var height = (System.Windows.Controls.TextBox)values[2];
                var weight = (System.Windows.Controls.TextBox)values[3];
                var goal = (System.Windows.Controls.TextBox)values[4];
                var rad_male = (System.Windows.Controls.RadioButton)values[5];
                var date = (DatePicker)values[6];
                var page = (Page)values[7];

                if (name.Text.Equals("Type your name") ||
                    !double.TryParse(height.Text, out double a) ||
                    !double.TryParse(weight.Text, out double b) ||
                    !double.TryParse(goal.Text, out double c))
                {
                    System.Windows.MessageBox.Show("값을 똑바로 입력하세요");
                }
                else
                {
                    Us.User.UserName = name.Text;
                    Us.User.UserBirth = birth.Text;
                    Us.User.UserHeight = double.Parse(height.Text);
                    Us.User.UserWeight = double.Parse(weight.Text);
                    Us.User.UserGoal = double.Parse(goal.Text);
                    Us.User.UserBMI = Math.Round(Us.User.UserWeight / ((Us.User.UserHeight / 100) * (Us.User.UserHeight / 100)), 1);
                    Us.User.UserAge = int.Parse(DateTime.Now.ToString("yyyy")) - int.Parse(Us.User.UserBirth.Substring(0, 4)) + 1;
                    if (date.Text == "")
                    {
                        Us.User.SaveDate = DateTime.Now.ToString("yyyyMMdd");
                    }
                    else
                    {
                        Us.User.SaveDate = date.Text.Replace("-", "");
                    }




                    if (rad_male.IsChecked == true)
                    {
                        Us.User.UserSex = "Male";
                        Us.User.UserGoalKcal = Math.Round(662 - (9.53 * Us.User.UserAge) + 1.11 * ((15.91 * Us.User.UserGoal) + 539.6 * (Us.User.UserHeight / 100)), 1);
                    }
                    else
                    {
                        Us.User.UserSex = "Female";
                        Us.User.UserGoalKcal = Math.Round(354 - (6.91 * Us.User.UserAge) + 1.12 * ((9.36 * Us.User.UserGoal) + 726 * (Us.User.UserHeight / 100)), 1);
                    }


                    Us.UserFoodList.Clear();
                    Us.UserActList.Clear();
                    Us.User.UserKcal = 0;
                    Us.User.UserCH = 0;
                    Us.User.UserPT = 0;
                    Us.User.UserFT = 0;
                    Us.User.UserST = 0;
                    Us.User.UserActKcal = 0;
                    Us.User.UserActMinute = 0;

                    System.Windows.MessageBox.Show("사용자 정보가 저장되었습니다!");
                    Window.GetWindow(page).Close();
                    Us.UserExist = true;
                }


            }
        }
    }
}