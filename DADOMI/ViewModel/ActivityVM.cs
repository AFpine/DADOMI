using DADOMI.Model;
using DADOMI.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DADOMI.ViewModel
{
    public class ActivityVM
    {
        public ActivityInfo Ac { get; set; }
        public ActivitySelectCommand ActivitySelectCommand { get; set; }
        public ActivityDeleteCommand ActivityDeleteCommand { get; set; }

        public ActivityVM()
        {
            Ac = new ActivityInfo();
            ActivitySelectCommand = new ActivitySelectCommand(this);
            ActivityDeleteCommand = new ActivityDeleteCommand(this);
        }
    }
}
