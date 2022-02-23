using DADOMI.View.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DADOMI.ViewModel.Command
{
    public class LoadButtonCommand : ICommand
    {
        FoodInformationControl Foodtemp { get; set; }
        ActivityInformationControl Acttemp { get; set; }
        UserVM Us;
        public LoadButtonCommand(UserVM u)
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
            Page p = (Page)parameter;
            string csvPath = "";
            System.Windows.Forms.OpenFileDialog filedlg = new System.Windows.Forms.OpenFileDialog();
            filedlg.InitialDirectory = Us.FileLoc;
            filedlg.Filter = "csv file(*.csv)|*.csv";
            if (filedlg.ShowDialog() == DialogResult.OK)
            {
                csvPath = filedlg.FileName;
                using (var reader = new StreamReader(csvPath))
                {
                    Us.UserFoodList.Clear();
                    Us.UserActList.Clear();
                    Us.User.UserKcal = 0;
                    Us.User.UserCH = 0;
                    Us.User.UserPT = 0;
                    Us.User.UserFT = 0;
                    Us.User.UserST = 0;
                    Us.User.UserActKcal = 0;
                    Us.User.UserActMinute = 0;

                    Us.User.SaveDate = csvPath.Substring(csvPath.Length - 12, 8);
                    while (true)
                    {
                        var line = reader.ReadLine().Split(',');
                        if (line[0] == "#") break;
                        switch (line[0])
                        {
                            case "UserName":
                                Us.User.UserName = line[1].Trim();
                                break;
                            case "UserBirth":
                                Us.User.UserBirth = line[1];
                                break;
                            case "UserAge":
                                Us.User.UserAge = int.Parse(line[1]);
                                break;
                            case "UserHeight":
                                Us.User.UserHeight = double.Parse(line[1]);
                                break;
                            case "UserWeight":
                                Us.User.UserWeight = double.Parse(line[1]);
                                break;
                            case "UserGoal":
                                Us.User.UserGoal = double.Parse(line[1]);
                                break;
                            case "UserSex":
                                Us.User.UserSex = line[1];
                                break;
                            case "UserBMI":
                                Us.User.UserBMI = double.Parse(line[1]);
                                break;
                            case "UserGoalKcal":
                                Us.User.UserGoalKcal = double.Parse(line[1]);
                                break;
                            case "UserKcal":
                                Us.User.UserKcal = double.Parse(line[1]);
                                break;
                            case "UserCH":
                                Us.User.UserCH = double.Parse(line[1]);
                                break;
                            case "UserPT":
                                Us.User.UserPT = double.Parse(line[1]);
                                break;
                            case "UserFT":
                                Us.User.UserFT = double.Parse(line[1]);
                                break;
                            case "UserST":
                                Us.User.UserST = double.Parse(line[1]);
                                break;
                            case "UserActKcal":
                                Us.User.UserActKcal = double.Parse(line[1]);
                                break;
                            case "UserActMinute":
                                Us.User.UserActMinute = double.Parse(line[1]);
                                break;
                        }
                    }
                    reader.ReadLine();
                    while (true)
                    {
                        var line = reader.ReadLine().Split(',');
                        if (line[0] == "#") break;
                        Foodtemp = new FoodInformationControl();
                        Foodtemp.FIC_name.Text = line[0];
                        Foodtemp.FIC_kcal.Text = $"{line[1]} kcal";
                        Foodtemp.FIC_size.Text = $"{line[2]} g";
                        Foodtemp.FIC_CH.Text = line[3];
                        Foodtemp.FIC_PT.Text = line[4];
                        Foodtemp.FIC_FT.Text = line[5];
                        Foodtemp.FIC_ST.Text = line[6];

                        Us.UserFoodList.Add(Foodtemp);
                    }
                    reader.ReadLine();
                    while (true)
                    {
                        var line = reader.ReadLine().Split(',');
                        if (line[0] == "#") break;
                        Acttemp = new ActivityInformationControl();
                        Acttemp.AIC_name.Text = line[0];
                        Acttemp.AIC_kcal.Text = $"{line[1]} kcal";
                        Acttemp.AIC_minute.Text = $"{line[2]} 분";


                        Us.UserActList.Add(Acttemp);
                    }


                }
                System.Windows.MessageBox.Show("Load Success!");
                Window.GetWindow(p).Close();
                Us.UserExist = true;
            }
        }
    }
}
