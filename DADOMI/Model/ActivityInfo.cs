using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DADOMI.Model
{
    public class ActivityInfo
    {
		private ObservableCollection<ActivityRow> activities;

		public ObservableCollection<ActivityRow> Activities
		{
			get { return activities; }
			set { activities = value; }
		}

		public ActivityInfo()
		{
			Activities = new ObservableCollection<ActivityRow>();
			Activities.Add(new ActivityRow("걷기", "26"));
			Activities.Add(new ActivityRow("달리기", "48"));
			Activities.Add(new ActivityRow("자전거", "56"));
			Activities.Add(new ActivityRow("줄넘기", "71"));
			Activities.Add(new ActivityRow("사이클", "48"));
			Activities.Add(new ActivityRow("런닝머신", "74"));
			Activities.Add(new ActivityRow("등산", "56"));
			Activities.Add(new ActivityRow("수영", "63"));
			Activities.Add(new ActivityRow("복싱", "71"));
			Activities.Add(new ActivityRow("에어로빅", "43"));
			Activities.Add(new ActivityRow("스쿼트", "48"));
			Activities.Add(new ActivityRow("윗몸일으키기", "56"));
		}
	}

	public class ActivityRow
	{
		public ActivityRow(string name, string kcal)
		{
			ActivityName = name;
			ActivityKcal = kcal;
		}
		private string activityName;

		public string ActivityName
		{
			get { return activityName; }
			set { activityName = value; }
		}

		private string activityKcal;

		public string ActivityKcal
		{
			get { return activityKcal; }
			set { activityKcal = value; }
		}

	}

}
