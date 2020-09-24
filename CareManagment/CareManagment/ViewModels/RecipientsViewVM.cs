using CareManagment.DP;
using CareManagment.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.ViewModels
{
    class RecipientsViewVM : BaseViewModel
    {
        public RecipientsViewM CurrentM { get; set; }

        public ObservableCollection<Recipient> Recipients { get; set; }
        public int Count { get { return Recipients.Count(); } }


        public RecipientsViewVM()
        {
            CurrentM = new RecipientsViewM();
            Recipients = new ObservableCollection<Recipient>(CurrentM.Recipients);
        }
    }
}
