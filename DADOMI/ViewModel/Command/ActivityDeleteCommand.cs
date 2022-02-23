using DADOMI.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class ActivityDeleteCommand : ICommand
    {
        public ActivityVM VM { get; set; }
        public ActivityInformationControl AIC { get; set; }

        public ActivityDeleteCommand(ActivityVM vm)
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

            for(int i = 0;i<Us.UserActList.Count;i++)
            {
                if (Us.UserActList[i].AIC_name.Text.ToString() == ((TextBlock)value[1]).Text.ToString() && Us.UserActList[i].AIC_minute.Text.ToString() == ((TextBlock)value[2]).Text.ToString())
                {
                    Us.User.UserActKcal -= double.Parse(Us.UserActList[i].AIC_kcal.Text.ToString().Replace(" kcal", ""));

                    if(Us.User.UserActKcal <0)
                    {
                        Us.User.UserActKcal = 0;
                    }
                    Us.User.UserActMinute -= double.Parse(Us.UserActList[i].AIC_minute.Text.ToString().Replace(" 분",""));
                    if (Us.User.UserActMinute < 0)
                    {
                        Us.User.UserActMinute = 0;
                    }
                    Us.UserActList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
