using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Windows.Forms;
using DADOMI.Model;
using System.Collections.ObjectModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace DADOMI.ViewModel.Command
{
    public class StatsButtonCommand : ICommand
    {
        
        public GraphVM Gr;
        public StatsButtonCommand(GraphVM g)
        {
            Gr = g;

        }
        public GraphInfo tempInfo { get; set; }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Gr.GraphList.Clear();
            var values = (object[])parameter;
            var Us = (UserVM)values[0];
            var Path = Us.FileLoc;
            DirectoryInfo di = new DirectoryInfo(Path);
            foreach (var item in di.GetFiles("*.csv", SearchOption.TopDirectoryOnly).OrderBy(f => f.Name.Substring(f.Name.Length - 12, 8)).ToList())
            {
                var N = item.Name.Remove(item.Name.Length - 12, 12);
                if (Us.User.UserName == N)
                {
                    tempInfo = new GraphInfo();
                    tempInfo.GDate = item.Name.Substring(item.Name.Length - 8, 4);
                    tempInfo.GDate = tempInfo.GDate.Insert(2, "/");
                    using (var reader = new StreamReader(item.FullName))
                    {
                        while (true)
                        {
                            var line = reader.ReadLine().Split(',');
                            if (line[0] == "#") break;
                            switch (line[0])
                            {
                                case "UserWeight":
                                    tempInfo.GWeight = double.Parse(line[1]);
                                    break;
                                case "UserBMI":
                                    tempInfo.GBMI = double.Parse(line[1]);
                                    break;
                                case "UserKcal":
                                    tempInfo.Gkcal = double.Parse(line[1]);
                                    break;
                                case "UserActKcal":
                                    tempInfo.GActKcal = double.Parse(line[1]);
                                    break;
                            }
                        }
                    }
                    Gr.GraphList.Add(tempInfo);
                }
            }

            Plot(Us);

            ((FrameVM)values[1]).MainFrameSource = new Uri("/View/Pages/StatsPage.xaml", UriKind.Relative);

        }

        //((LineSeries) MyChart.Series[0]).ItemsSource = new KeyValuePair<int, int>[] {
        //    new KeyValuePair<int, int>(0, 100),
        //    new KeyValuePair<int, int>(1, 130), 
        //    new KeyValuePair<int, int>(2, 150), 
        //};
        public KeyValuePair<string, double>[] KcalPair { get; set; }
        public KeyValuePair<string, double>[] WeightPair { get; set; }
        public KeyValuePair<string, double>[] ActivityPair { get; set; }
        public KeyValuePair<string, double>[] GoalKcalPair { get; set; }
        public KeyValuePair<string, double>[] GoalWeightPair { get; set; }
        public KeyValuePair<string, double>[] GoalActivityPair { get; set; }
        private void Plot(UserVM Us)
        {
            KcalPair = new KeyValuePair<string, double>[Gr.GraphList.Count];
            WeightPair = new KeyValuePair<string, double>[Gr.GraphList.Count];
            ActivityPair = new KeyValuePair<string, double>[Gr.GraphList.Count];
            GoalKcalPair = new KeyValuePair<string, double>[Gr.GraphList.Count];
            GoalWeightPair = new KeyValuePair<string, double>[Gr.GraphList.Count];
            GoalActivityPair = new KeyValuePair<string, double>[Gr.GraphList.Count];
            for(int i = 0;i<Gr.GraphList.Count;i++)
            {
                KcalPair[i] = new KeyValuePair<string, double>(Gr.GraphList[i].GDate, Gr.GraphList[i].Gkcal);
                WeightPair[i] = new KeyValuePair<string, double>(Gr.GraphList[i].GDate, Gr.GraphList[i].GWeight);
                ActivityPair[i] = new KeyValuePair<string, double>(Gr.GraphList[i].GDate, Gr.GraphList[i].GActKcal);

                GoalKcalPair[i] = new KeyValuePair<string, double>(Gr.GraphList[i].GDate,Us.User.UserGoalKcal);
                GoalWeightPair[i] = new KeyValuePair<string, double>(Gr.GraphList[i].GDate,Us.User.UserGoal);
            }
        }
    }
}


