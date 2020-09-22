using CareManagment.Commands;
using CareManagment.DP;
using CareManagment.ViewModels;
using CareManagment.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CareManagment.ViewModels
{
    public class DisplayDistributionsVM : BaseViewModel
    {
        public List<Distribution> DistributionsToUpdate { set; get; }

        public ObservableCollection<Distribution> NewDistributions { get; set; }
        public ObservableCollection<Distribution> OldDistributions { get; set; }


        public ICommand UpdateCollection { get { return new UpdateCollectionCommand(this); } }
        public ICommand SaveChangesCommand { get { return new SaveChangesCommand(this); } }



        private DistributionDetailsVM currentDetailsDisplay;
        public DistributionDetailsVM CurrentDetailsDisplay
        {
            get { return currentDetailsDisplay; }
            set
            {
                currentDetailsDisplay = value;
                OnPropertyRaised("CurrentDetailsDisplay");
            }
        }

        private PrintPdfVM currentPdfVM;
        public PrintPdfVM CurrentPdfVM
        {
            get { return currentPdfVM; }
            set
            {
                currentPdfVM = value;
                OnPropertyRaised("CurrentPdfVM");
            }
        }

        private DetailsPdfUC pdfView;
        public DetailsPdfUC PdfView
        {
            get { return pdfView; }
            set
            {
                pdfView = value;
                OnPropertyRaised("PdfView");
            }
        }

        private bool isDisplayingPdf;
        public bool IsDisplayingPdf
        {
            get { return isDisplayingPdf; }
            set
            {
                isDisplayingPdf = value;
                OnPropertyRaised("IsDisplayingPdf");
            }
        }

        private bool isDisplayingDetails;
        public bool IsDisplayingDetails
        {
            get { return isDisplayingDetails; }
            set
            {
                isDisplayingDetails = value;
                OnPropertyRaised("IsDisplayingDetails");
            }
        }

        public ICommand DisplayDetailsCommand { get { return new DisplayDistributionDetailsCommand(this); } }
        public ICommand DisplayPdfCommand { get { return new DisplayPdfCommand(this); } }

        public ICommand SavePdfCommand { get { return new BaseCommand(delegate () { PdfView.Print(); }); } }

        public void DisplayDetails(int DistributionId)
        {
            CurrentDetailsDisplay = new DistributionDetailsVM(DistributionId);
            IsDisplayingDetails = true;
        }

        public void DisplayPdf(int DistributionId)
        {
            CurrentPdfVM = new PrintPdfVM(DistributionId);
            PdfView = new DetailsPdfUC()
            {
                DataContext = CurrentPdfVM
            };
            IsDisplayingPdf = true;

        }

        public void CollectionChanged(Object o)
        {
            int Id = int.Parse(o.ToString());
            List<Distribution> AllDistributions = new List<Distribution>(OldDistributions);
            AllDistributions.AddRange(NewDistributions);
            Distribution distribution = AllDistributions.Find(x => x.DistributionId == Id);
            DistributionsToUpdate.Add(distribution);
            if (distribution.IsDelivered)
            {
                NewDistributions.Remove(distribution);
                OldDistributions.Add(distribution);
            }
            else
            {
                NewDistributions.Add(distribution);
                OldDistributions.Remove(distribution);

            }
        }

        public virtual void SaveChanges() { }

    }
}
