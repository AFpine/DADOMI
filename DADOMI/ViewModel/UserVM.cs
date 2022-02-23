using DADOMI.Model;
using DADOMI.View.UserControls;
using DADOMI.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DADOMI.ViewModel
{
    public class UserVM : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public UserInfo User { get; set; }
        public SaveButtonCommand SaveCommand { get; set; }
        public Userinfo_newInputCommand NewUserinfo_InputCommand { get; set; }
        public BrowseButtonCommand BrowseCommand { get; set; }
        public ObservableCollection<FoodInformationControl> UserFoodList { get; set; }
        public LoadButtonCommand LoadCommand { get; set; }
        public ObservableCollection<ActivityInformationControl> UserActList { get; set; }
        private bool userExist = false;
        public bool UserExist
        {
            get { return userExist; }
            set { userExist = value; OnPropertyChanged("UserExist"); }
        }

        public UserVM()
        {
            User = new UserInfo();
            SaveCommand = new SaveButtonCommand(this);
            NewUserinfo_InputCommand = new Userinfo_newInputCommand(this);
            UserFoodList = new ObservableCollection<FoodInformationControl>();
            LoadCommand = new LoadButtonCommand(this);
            BrowseCommand = new BrowseButtonCommand(this);
            UserActList = new ObservableCollection<ActivityInformationControl>();
        }

        private string fileLoc = @"C:\DADOMI_SaveFile";
        public string FileLoc
        {
            get { return fileLoc; }
            set { fileLoc = value; OnPropertyChanged("FileLoc"); }
        }



    }
}
