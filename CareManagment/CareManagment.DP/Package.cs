using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Package
    {
        public int Id { get; set; }
        public PkgType Contents { get; set; }
        


        private Recipient recipient;
        public Recipient Recipient
        {
            get { return recipient; }
            set
            {
                recipient = value;
                RecipientId = recipient.Id;
            }
        }
        public int RecipientId { get; set; }


        private Distribution distribution;
        public Distribution Distribution
        {
            get { return Distribution; }
            set
            {
                distribution = value;
                DistributionId = distribution.Id;
            }

        }
        public int DistributionId { get; set; }
    }
}
