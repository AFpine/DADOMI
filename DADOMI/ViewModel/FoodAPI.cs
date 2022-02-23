using DADOMI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DADOMI.ViewModel
{
    public class FoodAPI
    {
        public const string API_KEY = "47415e43709f4eeba43b";
        public const string BASE_URL = "http://openapi.foodsafetykorea.go.kr/api/{0}/I2790/json/1/500/DESC_KOR={1}";

        public static FoodInfo GetFoodInfo(string foodName)
        {
            FoodInfo result = new FoodInfo();
            string url = string.Format(BASE_URL, API_KEY, foodName);

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(url);
                string json = response.Result.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<FoodInfo>(json);
            }
            return result;
        }
    }
}
