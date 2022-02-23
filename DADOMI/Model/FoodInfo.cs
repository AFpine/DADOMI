using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DADOMI.Model
{
    public class FoodInfo : INotifyPropertyChanged
    {
        [JsonProperty("I2790")]
        private I2790 I2790;

        public I2790 FOOD_INFO
        {
            get { return I2790; }
            set { I2790 = value; OnPropertyChanged("FOOD_INFO"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Row : INotifyPropertyChanged
    {
        [JsonProperty("NUTR_CONT3")]
        private string NUTR_CONT3;
        public string FOOD_PROTEIN
        {
            get { return NUTR_CONT3; }
            set { NUTR_CONT3 = value; OnPropertyChanged(nameof(FOOD_PROTEIN)); }
        }

        [JsonProperty("NUTR_CONT2")]
        private string NUTR_CONT2;
        public string FOOD_CARHIDE
        {
            get { return NUTR_CONT2; }
            set { NUTR_CONT2 = value; OnPropertyChanged(nameof(FOOD_CARHIDE)); }
        }

        [JsonProperty("NUTR_CONT1")]
        private string NUTR_CONT1;
        public string FOOD_KCAL
        {
            get { return NUTR_CONT1; }
            set { NUTR_CONT1 = value; OnPropertyChanged(nameof(FOOD_KCAL)); }
        }

        [JsonProperty("SERVING_SIZE")]
        private string SERVING_SIZE;
        public string FOOD_SIZE
        {
            get { return SERVING_SIZE; }
            set { SERVING_SIZE = value; OnPropertyChanged(nameof(FOOD_SIZE)); }
        }

        [JsonProperty("NUTR_CONT5")]
        private string NUTR_CONT5;
        public string FOOD_SWEET
        {
            get { return NUTR_CONT5; }
            set { NUTR_CONT5 = value; OnPropertyChanged(nameof(FOOD_SWEET)); }
        }

        [JsonProperty("NUTR_CONT4")]
        private string NUTR_CONT4;
        public string FOOD_FAT
        {
            get { return NUTR_CONT4; }
            set { NUTR_CONT4 = value; OnPropertyChanged(nameof(FOOD_FAT)); }
        }

        [JsonProperty("DESC_KOR")]
        private string DESC_KOR;
        public string FOOD_NAME
        {
            get { return DESC_KOR; }
            set { DESC_KOR = value; OnPropertyChanged(nameof(FOOD_NAME)); }
        }

        [JsonProperty("NUM")]
        private string NUM;
        public string FOOD_INDEX
        {
            get { return NUM; }
            set { NUM = value; OnPropertyChanged(nameof(FOOD_INDEX)); }
        }

        [JsonProperty("MAKER_NAME")]
        private string MAKER_NAME;

        public string FOOD_MAKER
        {
            get { return MAKER_NAME; }
            set { MAKER_NAME = value; OnPropertyChanged(nameof(MAKER_NAME)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class I2790 : INotifyPropertyChanged
    {
        [JsonProperty("total_count")]
        private string total_count;

        public string TOTAL_COUNT
        {
            get { return total_count; }
            set { total_count = value; OnPropertyChanged("TOTAL_COUNT"); }
        }

        [JsonProperty("row")]
        private IList<Row> row;

        public IList<Row> FOOD_LIST
        {
            get { return row; }
            set { row = value; OnPropertyChanged("FOOD_LIST"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    
}
