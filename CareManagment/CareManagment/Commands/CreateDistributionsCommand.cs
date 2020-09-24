using CareManagment.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.Commands
{
    class CreateDistributionsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AddDistributionVM CurrentVM { get; set; }
        public BackgroundWorker CreateDistributionsBW;

        public CreateDistributionsCommand(AddDistributionVM VM)
        {
            CurrentVM = VM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CreateDistributionsBW = new BackgroundWorker();
            CreateDistributionsBW.DoWork += CreateDistributions;
            CreateDistributionsBW.RunWorkerCompleted += DoneCreating;
            CreateDistributionsBW.RunWorkerAsync(parameter);
        }

        private void CreateDistributions(object sender, DoWorkEventArgs e)
        {
            CurrentVM.IsWorking = true;
            Thread.Sleep(1000);
            CurrentVM.CreateDistributions();
        }

        private void DoneCreating(object sender, RunWorkerCompletedEventArgs e)
        {
            CurrentVM.IsWorking = false;           
        }
       
    }
}
