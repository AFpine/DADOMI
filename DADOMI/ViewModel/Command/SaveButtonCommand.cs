using DADOMI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class SaveButtonCommand : ICommand
    {
        public UserVM Us;
        public SaveButtonCommand(UserVM u)
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

            

            string fileName = $"{Us.User.UserName}{Us.User.SaveDate}";
            DirectoryInfo di = new DirectoryInfo(Us.FileLoc);
            if (di.Exists == false) di.Create();

            // # -> End-Of-File
            using (StreamWriter file = new StreamWriter($@"{Us.FileLoc}\{fileName}.csv", false, System.Text.Encoding.GetEncoding("utf-8")))
            {
                file.WriteLine("UserName,{0}", Us.User.UserName);
                file.WriteLine("UserBirth,{0}", Us.User.UserBirth);
                file.WriteLine("UserAge,{0}", Us.User.UserAge);
                file.WriteLine("UserHeight,{0}", Us.User.UserHeight);
                file.WriteLine("UserWeight,{0}", Us.User.UserWeight);
                file.WriteLine("UserGoal,{0}", Us.User.UserGoal);
                file.WriteLine("UserSex,{0}", Us.User.UserSex);
                file.WriteLine("UserBMI,{0}", Us.User.UserBMI);
                file.WriteLine("UserGoalKcal,{0}", Us.User.UserGoalKcal);
                file.WriteLine("UserKcal,{0}", Us.User.UserKcal);
                file.WriteLine("UserCH,{0}", Us.User.UserCH);
                file.WriteLine("UserPT,{0}", Us.User.UserPT);
                file.WriteLine("UserFT,{0}", Us.User.UserFT);
                file.WriteLine("UserST,{0}", Us.User.UserST);
                file.WriteLine("UserActKcal,{0}", Us.User.UserActKcal);
                file.WriteLine("UserActMinute,{0}", Us.User.UserActMinute);
                file.WriteLine("#");

                file.WriteLine("FIC_name, FIC_kcal, FIC_size, FIC_CH, FIC_PT, FIC_FT, FIC_ST");
                for (int i = 0; i < Us.UserFoodList.Count; i++)
                {
                    string name = Us.UserFoodList[i].FIC_name.Text.Replace(","," ");
                    string kcal = Us.UserFoodList[i].FIC_kcal.Text.Replace(" kcal", "").Replace(",", "");
                    string size = Us.UserFoodList[i].FIC_size.Text.Replace(" g", "").Replace(",", "");
                    double ch = double.Parse(Us.UserFoodList[i].FIC_CH.Text.ToString());
                    double pt = double.Parse(Us.UserFoodList[i].FIC_PT.Text.ToString());
                    double ft = double.Parse(Us.UserFoodList[i].FIC_FT.Text.ToString());
                    double st = double.Parse(Us.UserFoodList[i].FIC_ST.Text.ToString());

                    file.WriteLine("{0},{1},{2},{3},{4},{5},{6}", name, kcal, size, ch, pt, ft, st);

                }
                file.WriteLine("#");


                file.WriteLine("AIC_name, AIC_kcal, AIC_minute");
                for (int i = 0; i < Us.UserActList.Count; i++)
                {
                    string name = Us.UserActList[i].AIC_name.Text;
                    double kcal = double.Parse(Us.UserActList[i].AIC_kcal.Text.Replace(" kcal",""));
                    double minute = double.Parse(Us.UserActList[i].AIC_minute.Text.Replace(" 분",""));
                    file.WriteLine("{0},{1},{2}", name, kcal, minute);
                }
                file.WriteLine("#");

            }
            System.Windows.MessageBox.Show("Save Success!");
        }
    }
}
