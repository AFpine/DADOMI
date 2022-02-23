using DADOMI.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class FoodSearchCommannd : ICommand, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnpropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public FoodVM VM { get; set; }
        private string inputFood = "음식 이름";
        public string InputFood
        {
            get { return inputFood; }
            set { inputFood = value; OnpropertyChanged("InputFood"); }
        }
        public FoodSearchCommannd(FoodVM vm)
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

            if (InputFood != null && !InputFood.Equals("음식 이름"))
            {
                VM.FoodName = InputFood;
                if (VM.Food.FOOD_INFO.TOTAL_COUNT != "0")
                {
                    FoodSearchListWindow fslw = new FoodSearchListWindow();
                    fslw.ShowDialog();
                }
                else
                {
                    MessageBox.Show("음식 검색 결과가 없습니다");
                }

                InputFood = "음식 이름";
            }
        }
    }
}
