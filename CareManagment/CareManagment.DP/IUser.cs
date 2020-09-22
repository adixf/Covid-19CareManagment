using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public interface IUser
    {
        Address GetAddress();
        void SetAddress(double lat, double lon);
        string GetMailAddress();
        string GetFirstName();
        string GetLastName();
        string GetPassword();
    }
}
