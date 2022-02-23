using DADOMI.Model;
using DADOMI.View.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DADOMI.ViewModel.Command
{
    public class MenuNavigationCommand : ICommand
    {
        public FrameVM Frm;
        public MenuNavigationCommand(FrameVM Vm)
        {
            Frm = Vm;
        }
        
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var menu = (string)parameter;

            switch (menu)
            {
                // MainPage
                case "Home":
                    Frm.MainFrameSource = new Uri("/View/Pages/MainPage.xaml", UriKind.Relative);
                    break;
                case "Food":
                    Frm.MainFrameSource = new Uri("/View/Pages/FoodPage.xaml", UriKind.Relative);
                    break;
                case "Activity":
                    Frm.MainFrameSource = new Uri("/View/Pages/ActivityPage.xaml", UriKind.Relative);
                    break;
                
            }
        }
    }
}
