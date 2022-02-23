using DADOMI.Model;
using DADOMI.View.Pages;
using DADOMI.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DADOMI.ViewModel
{
    public class GraphVM
    {
        public StatsButtonCommand StatsCommand { get; set; }
        public ObservableCollection<GraphInfo> GraphList { get; set; }
        public Chart GraphChart { get; set; }
            
        public GraphVM()
        {
            StatsCommand = new StatsButtonCommand(this);
            GraphList = new ObservableCollection<GraphInfo>();
            GraphChart = new Chart();
        }

        

    }
}