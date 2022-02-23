using DADOMI.Model;
using DADOMI.View.UserControls;
using DADOMI.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DADOMI.ViewModel
{
    public class FoodVM
    {

        public FoodInfo Food { get; set; }
        public FoodSearchCommannd FoodSearchCommand { get; set; }
        public FoodSelectCommand FoodSelectCommand { get; set; }
        public FoodDeleteCommand FoodDeleteCommand { get; set; }
        public FoodVM()
        {
            Food = new FoodInfo();
            FoodSearchCommand = new FoodSearchCommannd(this);
            FoodSelectCommand = new FoodSelectCommand(this);
            FoodDeleteCommand = new FoodDeleteCommand(this);
        }

        private string foodName;
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; GetFood(); }
        }
        public void GetFood()
        {
            if (foodName != null)
            {
                var food = FoodAPI.GetFoodInfo(FoodName);
                Food.FOOD_INFO = food.FOOD_INFO;
            }
        }

    }
}
