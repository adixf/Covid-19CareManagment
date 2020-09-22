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
    public class PrintPdfM
    {
        public Distribution Distribution { get; set; }
        public Volunteer Volunteer { get; set; }
        public List<Package> Packages { get; set; }

        public IBL BL { get; set; }

        public PrintPdfM(int DistributionId)
        {
            BL = new BLImp();
            Distribution = BL.GetAllDistributions(d => d.DistributionId == DistributionId).First();
            Packages = BL.GetAllPackages(p => p.DistributionId == DistributionId);
            Volunteer = BL.GetAllVolunteers(v => v.VolunteerId == Distribution.VolunteerId).First();
        }
        
    }
}
