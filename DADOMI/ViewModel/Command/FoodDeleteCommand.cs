using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class FoodDeleteCommand : ICommand
    {
        public FoodVM VM { get; set; }
        public FoodDeleteCommand(FoodVM vm)
        {
            VM = vm;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var value = (object[])parameter;
            var Us = (UserVM)value[0];

            for (int i = 0; i < Us.UserFoodList.Count; i++)
            {   //*
                if (Us.UserFoodList[i].FIC_name.Text.ToString() == ((TextBlock)value[1]).Text.ToString() && Us.UserFoodList[i].FIC_size.Text.ToString() == ((TextBlock)value[2]).Text.ToString())
                {
                    Us.User.UserKcal -= double.Parse(Us.UserFoodList[i].FIC_kcal.Text.ToString().Replace(" kcal",""));
                    Us.User.UserCH -= double.Parse(Us.UserFoodList[i].FIC_CH.Text.ToString());
                    Us.User.UserPT -= double.Parse(Us.UserFoodList[i].FIC_PT.Text.ToString());
                    Us.User.UserFT -= double.Parse(Us.UserFoodList[i].FIC_FT.Text.ToString());
                    Us.User.UserST -= double.Parse(Us.UserFoodList[i].FIC_ST.Text.ToString());
                    Us.UserFoodList.RemoveAt(i);
                    if(Us.User.UserKcal < 1)
                    {
                        Us.User.UserKcal = 0;
                    }
                    if (Us.User.UserCH < 1)
                    {
                        Us.User.UserCH = 0;
                    }
                    if (Us.User.UserPT < 1)
                    {
                        Us.User.UserPT = 0;
                    }
                    if (Us.User.UserFT < 1)
                    {
                        Us.User.UserFT = 0;
                    }
                    if (Us.User.UserST < 1)
                    {
                        Us.User.UserST = 0;
                    }
                    //*
                    break;
                }
            }
        }
    }
}
