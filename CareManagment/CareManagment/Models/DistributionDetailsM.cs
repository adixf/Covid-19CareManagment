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
   public class DistributionDetailsM
   {
        public IBL BL { get; set; }


        public DistributionDetailsM()
        {
            BL = new BLImp();
        }


        public Distribution GetDistribution(int DistributionId)
        {
            return BL.GetAllDistributions().Where(d => d.DistributionId == DistributionId).First();
        }

        public List<Package> GetAllPackages(int DistributionId)
        {
            return BL.GetAllPackages(p => p.DistributionId == DistributionId);
        }
   }
}
