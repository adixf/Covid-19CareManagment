using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Package
    {
        public int PackageId { get; set; }
        public PkgType Contents { get; set; }
        

        private Recipient recipient;
        public Recipient Recipient
        {
            get { return recipient; }
            set
            {
                recipient = value;
                if(value!=null) RecipientId = recipient.RecipientId;
            }
        }
        public int RecipientId { get; set; }


        private Distribution distribution;
        public Distribution Distribution
        {
            get { return distribution; }
            set
            {
                distribution = value;
                if(value!=null) DistributionId = distribution.DistributionId;
            }

        }
        public int DistributionId { get; set; }
    }
}
