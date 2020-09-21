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
        public ObservableCollection<Volunteer> Volunteers { get; set; }
        public VolunteersViewM CurrentM { get; set; }
        public VolunteersViewVM()
        {
            CurrentM = new VolunteersViewM();
            Volunteers = new ObservableCollection<Volunteer>(CurrentM.Volunteers);
        }
    }
}
