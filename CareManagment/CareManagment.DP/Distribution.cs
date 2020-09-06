using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Distribution
    {
        public int Id { get; set; }
        public User Volunteer { get; set; }
        public List<Package> Packages { get; set; }
        public DateTime Date { get; set; }
        public User Admin { get; set; }
        public bool IsDelivered { get; set; }
    }
}
