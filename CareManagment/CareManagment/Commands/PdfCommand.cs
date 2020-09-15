using CareManagment.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CareManagment.Commands
{
    public class PdfCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public PdfVM CurrentVM { get; set; }
        public PdfCommand(PdfVM VM)
        {
            CurrentVM = VM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            PrintDialog pdf = new PrintDialog();
           
            
        }
        
    }
}
