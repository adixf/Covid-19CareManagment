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

        public ObservableCollection<Volunteer> Volunteers { get; set; }
        public int Count { get { return Volunteers.Count(); } }

        public VolunteersViewVM()
        {
            CurrentM = new VolunteersViewM();
            Volunteers = new ObservableCollection<Volunteer>(CurrentM.Volunteers);
        }
    }
}
