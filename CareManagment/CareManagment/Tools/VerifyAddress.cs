using CareManagment.BL;
using CareManagment.DP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CareManagment.Tools
{
    class VerifyAddress
    {
        public bool IsValidAddress(Address address)
        {
            JsonAddress AddressDetails = new BLImp().GetAddressDetails(address);
            return AddressDetails.DisplayName.Contains(address.Street) && AddressDetails.DisplayName.Contains(address.City);
        }
        

    }
}
