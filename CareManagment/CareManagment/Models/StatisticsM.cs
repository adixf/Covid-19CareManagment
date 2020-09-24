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
    public class StatisticsM
    {
        public IBL BL { get; set; }
        public int[] Planned { get; set; }
        public int[] Delivered { get; set; }


        public StatisticsM()
        {
            BL = new BLImp();
            GetStatistics(7);
        }

        public void GetStatistics(int PreviousDays)
        {
            DateTime Today = DateTime.Now.Date;
            DateTime WeekAgo = Today.AddDays(-PreviousDays);

            Planned = new int[PreviousDays];
            Delivered = new int[PreviousDays]; 

            List<Distribution> Distributions = BL.GetAllDistributions();
            foreach (Distribution distribution in Distributions)
                if (Today >= distribution.Date.Date && distribution.Date.Date > WeekAgo)
                // distribution was created within a week
                {
                    int dayIndex = PreviousDays - 1 - (int)(Today - distribution.Date.Date).TotalDays;
                    Planned[dayIndex]++;
                    if(distribution.IsDelivered)
                        Delivered[dayIndex]++;
                }                   

        }

    }
}
