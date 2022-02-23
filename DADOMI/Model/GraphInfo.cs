using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DADOMI.Model
{
    public class GraphInfo
    {
        private string gDate;
        public string GDate
        {
            get { return gDate; }
            set { gDate = value; }
        }

        private double gBMI;
        public double GBMI
        {
            get { return gBMI; }
            set { gBMI = value; }
        }

        private double gWeight;
        public double GWeight
        {
            get { return gWeight; }
            set { gWeight = value; }
        }

        private double gKcal;
        public double Gkcal
        {
            get { return gKcal; }
            set { gKcal = value; }
        }

        private double gActKcal;
        public double GActKcal
        {
            get { return gActKcal; }
            set { gActKcal = value; }
        }
    }
}
