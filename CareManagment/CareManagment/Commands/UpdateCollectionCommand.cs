using CareManagment.Interfaces;
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
    class UpdateCollectionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public BackgroundWorker CheckDistributionBW;
        public IUpdateCollection CurrentVM { get; set; }

        public UpdateCollectionCommand(IUpdateCollection vm)
        {
            CurrentVM = vm;
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CheckDistributionBW = new BackgroundWorker();            
            CheckDistributionBW.DoWork += Wait;
            CheckDistributionBW.RunWorkerCompleted += DoneWaiting;
            CheckDistributionBW.RunWorkerAsync(parameter);
           
        }

        private void Wait(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
            Thread.Sleep(250);
        }

        private void DoneWaiting(object sender, RunWorkerCompletedEventArgs e)
        {
            CurrentVM.CollectionChanged(e.Result);
        }
    }
}
