using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace DADOMI.ViewModel.Command
{
    public class BrowseButtonCommand : ICommand
    {
        UserVM Us;
        public BrowseButtonCommand(UserVM u)
        {
            Us = u;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ////저장경로 if else로 
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Us.FileLoc = fbd.SelectedPath;
            }
        }
    }
}
