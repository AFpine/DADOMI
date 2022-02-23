using DADOMI.View.Pages;
using DADOMI.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace DADOMI.ViewModel
{
    public class FrameVM : INotifyPropertyChanged
    {


        private Uri mainfFrameSource = new Uri("/View/Pages/StartPage.xaml", UriKind.Relative);
        public Uri MainFrameSource
        {
            get { return mainfFrameSource; }
            set
            {
                mainfFrameSource = value;
                OnPropertyChanged("MainFrameSource");
            }
        }
        private Uri userinfoFrameSource = new Uri("/View/Pages/UserinfoPage.xaml", UriKind.Relative);
        public Uri UserinfoFrameSource
        {
            get { return userinfoFrameSource; }
            set
            {
                userinfoFrameSource = value;
                OnPropertyChanged("UserinfoFrameSource");
            }
        }

        public MenuNavigationCommand naviCommand { get; set; }
        public HelpButtonCommand helpCommand { get; set; }
        public UserinfoWindowNaviCommand userinfoCommand { get; set; }
        public UserButtonCommand userCommand { get; set; }
       
        public FrameVM()
        {
            naviCommand = new MenuNavigationCommand(this);
            helpCommand = new HelpButtonCommand();
            userinfoCommand = new UserinfoWindowNaviCommand(this);
            userCommand = new UserButtonCommand(this);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handle = PropertyChanged;
            if (handle != null)
            {
                handle(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
