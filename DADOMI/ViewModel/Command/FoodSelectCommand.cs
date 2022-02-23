using DADOMI.View.UserControls;
using DADOMI.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class FoodSelectCommand : ICommand
    {
        public FoodVM VM { get; set; }
        public FoodInformationControl FIC { get; set; }
        private int selectIndex;

        public int SelectIndex
        {
            get { return selectIndex; }
            set { selectIndex = value; }
        }

        private string eatenSize = "섭취량";

        public string EatenSize
        {
            get { return eatenSize; }
            set { eatenSize = value; }
        }

        public FoodSelectCommand(FoodVM vm)
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

            if (SelectIndex >= 0)
            {
                FIC = new FoodInformationControl();
                FIC.FIC_name.Text = VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_NAME;
                if (VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_CARHIDE == "")
                {
                    VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_CARHIDE = "0";
                }
                if (VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_PROTEIN == "")
                {
                    VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_PROTEIN = "0";
                }
                if (VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_FAT == "")
                {
                    VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_FAT = "0";
                }
                if (VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SWEET == "")
                {
                    VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SWEET = "0";
                }
                if (EatenSize != "" && double.TryParse(EatenSize, out double a) && a > 0)
                {
                    FIC.FIC_kcal.Text = ((double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_KCAL)) / (double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SIZE)) * double.Parse(EatenSize)).ToString("N1") + " kcal";
                    FIC.FIC_size.Text = double.Parse(EatenSize).ToString("N1") + " g";
                    FIC.FIC_CH.Text = ((double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_CARHIDE)) / (double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SIZE)) * double.Parse(EatenSize)).ToString("N1");
                    FIC.FIC_PT.Text = ((double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_PROTEIN)) / (double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SIZE)) * double.Parse(EatenSize)).ToString("N1");
                    FIC.FIC_FT.Text = ((double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_FAT)) / (double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SIZE)) * double.Parse(EatenSize)).ToString("N1");
                    FIC.FIC_ST.Text = ((double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SWEET)) / (double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SIZE)) * double.Parse(EatenSize)).ToString("N1");

                    Us.User.UserKcal += double.Parse(FIC.FIC_kcal.Text.ToString().Replace(" kcal", ""));
                    Us.User.UserCH += double.Parse(FIC.FIC_CH.Text.ToString());
                    Us.User.UserPT += double.Parse(FIC.FIC_PT.Text.ToString());
                    Us.User.UserFT += double.Parse(FIC.FIC_FT.Text.ToString());
                    Us.User.UserST += double.Parse(FIC.FIC_ST.Text.ToString());
                    EatenSize = "섭취량";
                    Us.UserFoodList.Add(FIC);
                    ((FoodSearchListWindow)value[1]).Close();
                }
                else if ((EatenSize != "") && double.TryParse(EatenSize, out double b) && b == 0)
                {
                    FIC.FIC_kcal.Text = double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_KCAL).ToString("N1") + " kcal";
                    FIC.FIC_size.Text = double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SIZE).ToString("N1") + " g";
                    FIC.FIC_CH.Text = double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_CARHIDE).ToString("N1");
                    FIC.FIC_PT.Text = double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_PROTEIN).ToString("N1");
                    FIC.FIC_FT.Text = double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_FAT).ToString("N1");
                    FIC.FIC_ST.Text = double.Parse(VM.Food.FOOD_INFO.FOOD_LIST[SelectIndex].FOOD_SWEET).ToString("N1");

                    Us.User.UserKcal += double.Parse(FIC.FIC_kcal.Text.ToString().Replace(" kcal", ""));
                    Us.User.UserCH += double.Parse(FIC.FIC_CH.Text.ToString());
                    Us.User.UserPT += double.Parse(FIC.FIC_PT.Text.ToString());
                    Us.User.UserFT += double.Parse(FIC.FIC_FT.Text.ToString());
                    Us.User.UserST += double.Parse(FIC.FIC_ST.Text.ToString());
                    EatenSize = "섭취량";
                    Us.UserFoodList.Add(FIC);
                    ((FoodSearchListWindow)value[1]).Close();
                }
            }
        }
    }
}