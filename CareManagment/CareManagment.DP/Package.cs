using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Package
    {
        public Recipient Recipient { get; set; }
        public List<PkgType> Contents { get; set; }
    }
}
