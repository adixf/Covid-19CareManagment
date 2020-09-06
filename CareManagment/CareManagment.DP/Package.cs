using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Package
    {
        public Person Recipient { get; set; }
        public PkgType Contents { get; set; }
        public string Id { get; set; }
    }
}
