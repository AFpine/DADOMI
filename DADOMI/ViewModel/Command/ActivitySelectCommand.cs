using DADOMI.View.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class ActivitySelectCommand : ICommand, INotifyPropertyChanged
    {
        public ActivityVM VM { get; set; }
        public ActivityInformationControl AIC { get; set; }

        public ActivitySelectCommand(ActivityVM vm)
        {
            VM = vm;
        }

        private int selectIndex;

        public int SelectIndex
        {
            get { return selectIndex; }
            set { selectIndex = value; }
        }

        private string actMinute = "운동 시간(분)";
        public string ActMinute
        {
            get { return actMinute; }
            set { actMinute = value; OnPropertyChanged("ActMinute"); }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var value = (object[])parameter;
            var Us = (UserVM)value[0];


            if (SelectIndex >= 0 && double.TryParse(ActMinute, out double a) && a > 0)
            {
                AIC = new ActivityInformationControl();
                AIC.AIC_name.Text = VM.Ac.Activities[SelectIndex].ActivityName;
                AIC.AIC_minute.Text = ActMinute + " 분";
                AIC.AIC_kcal.Text = (((double.Parse(VM.Ac.Activities[SelectIndex].ActivityKcal) * Us.User.UserWeight) * double.Parse(ActMinute)) / 400.0).ToString("N1") + " kcal";
                Us.UserActList.Add(AIC);
                Us.User.UserActKcal += double.Parse(AIC.AIC_kcal.Text.ToString().Replace(" kcal", ""));
                Us.User.UserActMinute += double.Parse(AIC.AIC_minute.Text.ToString().Replace(" 분", ""));
            }
            ((TextBox)value[1]).Text = "0";
            ActMinute = "운동 시간";
        }
    }
}
