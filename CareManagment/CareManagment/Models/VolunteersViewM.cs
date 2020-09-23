using CareManagment.BL;
using CareManagment.BL.Interfaces;
using CareManagment.DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.Models
{
    class VolunteersViewM
    {
        public IBL BL { get; set; }

        public List<Volunteer> Volunteers { get; set; }


        public VolunteersViewM()
        {
            BL = new BLImp();

            Volunteers = new List<Volunteer>(BL.GetAllVolunteers());
        }
    }
}
