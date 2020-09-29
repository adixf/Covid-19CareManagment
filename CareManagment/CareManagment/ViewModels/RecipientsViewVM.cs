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

        private ObservableCollection<Recipient> recipients;
        public ObservableCollection<Recipient> Recipients
        {
            get { return recipients; }
            set
            {
                recipients = value;
                OnPropertyRaised("Recipients");
                Count = Recipients.Count;
            }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyRaised("Count");
            }
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyRaised("SearchText");
                if (value.Equals(string.Empty))
                    Recipients = new ObservableCollection<Recipient>(CurrentM.Recipients);
                else
                    Recipients = new ObservableCollection<Recipient>(Recipients.Where(r => Contains(r, value)));
            }
        }


        public RecipientsViewVM()
        {
            CurrentM = new RecipientsViewM();
            Recipients = new ObservableCollection<Recipient>(CurrentM.Recipients);
        }


        private bool Contains(Recipient r, string val)
        {
            if (r.FirstName.Contains(val)) return true;
            if (r.LastName.Contains(val)) return true;
            if (r.Address.ToString().Contains(val)) return true;
            if (r.MailAddress.Contains(val)) return true;
            if (r.PhoneNumber.Contains(val)) return true;
            return false;
        }
    }
}
