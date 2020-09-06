using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class User : Person
    {
        public string Password { get; set; }
        public TypePerson TypePerson { set; get; }
    }
}
