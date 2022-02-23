using DADOMI.Model;
using DADOMI.View.Pages;
using DADOMI.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DADOMI.ViewModel.Command
{
    public class UserinfoWindowNaviCommand : ICommand
    {
        public FrameVM Frm;
        public UserinfoWindowNaviCommand(FrameVM Vm)
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

            Frm.UserinfoFrameSource = new Uri("/View/Pages/Userinfo_newInputPage.xaml", UriKind.Relative);

        }
    }

}
