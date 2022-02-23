using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DADOMI.Model
{
    public class UserInfo:INotifyPropertyChanged
    {

		private string userName = "김형기";
		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}

		// 8자리
		private string userBirth;
		public string UserBirth
		{
			get { return userBirth; }
			set { userBirth = value; }
		}

		private int userAge;
		public int UserAge
		{
			get { return userAge; }
			set { userAge = value; }
		}


		private double userWeight;
		public double UserWeight
		{
			get { return userWeight; }
			set { userWeight = value; }
		}

		private double userHeight;
		public double UserHeight
		{
			get { return userHeight; }
			set { userHeight = value; }
		}

		private double userGoal;
		public double UserGoal
		{
			get { return userGoal; }
			set { userGoal = value; }
		}

		private string userSex;
		public string UserSex
		{
			get { return userSex; }
			set { userSex = value; }
		}

		private double userBMI;
		public double UserBMI
		{
			get { return userBMI; }
			set { userBMI = value; }
		}
		private double userGoalKcal;

		public double UserGoalKcal
		{
			get { return userGoalKcal; }
			set { userGoalKcal = value; }
		}



		private double userKcal;

		public double UserKcal
		{
			get { return userKcal; }
			set { userKcal = value; OnPropertyChanged(nameof(UserKcal)); }
		}

		private double userCH;

		public double UserCH
		{
			get { return userCH; }
			set { userCH = value; OnPropertyChanged(nameof(UserCH)); }
		}

		private double userPT;

		public double UserPT
		{
			get { return userPT; }
			set { userPT = value; OnPropertyChanged(nameof(UserPT)); }
		}

		private double userFT;

		public double UserFT
		{
			get { return userFT; }
			set { userFT = value; OnPropertyChanged(nameof(UserFT)); }
		}

		private double userST;
		public double UserST
		{
			get { return userST; }
			set { userST = value; OnPropertyChanged(nameof(UserST)); }
		}

		private string saveDate = DateTime.Now.ToString("yyyyMMdd");
		public string SaveDate
		{
			get { return saveDate; }
			set { saveDate = value; }
		}

		private double userActKcal;

		public double UserActKcal
		{
			get { return userActKcal; }
			set { userActKcal = value; OnPropertyChanged(nameof(UserActKcal)); }
		}

		private double userActMinute;

		public double UserActMinute
		{
			get { return userActMinute; }
			set { userActMinute = value; OnPropertyChanged(nameof(UserActMinute)); }
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
