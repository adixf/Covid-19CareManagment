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
        public ObservableCollection<Recipient> Recipients { get; set; }
        public RecipientsViewM CurrentM { get; set; }
        public RecipientsViewVM()
        {
            CurrentM = new RecipientsViewM();
            Recipients = new ObservableCollection<Recipient>(CurrentM.Recipients);
        }
    }
}
