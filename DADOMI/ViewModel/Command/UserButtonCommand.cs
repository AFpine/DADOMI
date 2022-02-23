using DADOMI.Model;
using DADOMI.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{

    public class UserButtonCommand : ICommand
    {
        public FrameVM Frm;
        public UserButtonCommand(FrameVM Vm)
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
            UserinfoWindow Win = new UserinfoWindow();
            Win.ShowDialog();
            Frm.UserinfoFrameSource = new Uri("/View/Pages/UserinfoPage.xaml", UriKind.Relative);
        }
    }
}
