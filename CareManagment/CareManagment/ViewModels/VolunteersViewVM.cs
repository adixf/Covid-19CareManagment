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
    class VolunteersViewVM : BaseViewModel
    {
        public VolunteersViewM CurrentM { get; set; }

        private ObservableCollection<Volunteer> volunteers;
        public ObservableCollection<Volunteer> Volunteers
        {
            get { return volunteers; }
            set
            {
                volunteers = value;
                OnPropertyRaised("Volunteers");
                    
            }
        }
        public int Count { get { return Volunteers.Count(); } }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyRaised("SearchText");
                if (value.Equals(string.Empty))
                    Volunteers = new ObservableCollection<Volunteer>(CurrentM.Volunteers);
                else
                    Volunteers = new ObservableCollection<Volunteer>(Volunteers.Where(v=>Contains(v, value)));
            }
        }


        public VolunteersViewVM()
        {
            CurrentM = new VolunteersViewM();
            Volunteers = new ObservableCollection<Volunteer>(CurrentM.Volunteers);
        }


        private bool Contains(Volunteer v, string val)
        {
            if (v.FirstName.Contains(val)) return true;
            if (v.LastName.Contains(val)) return true;
            if (v.Address.ToString().Contains(val)) return true;
            if (v.MailAddress.Contains(val)) return true;
            return false;
        }
    }
}
