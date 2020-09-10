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
            return AddressDetails.Description.Contains(address.Street) && AddressDetails.Description.Contains(address.City);
        }
        

    }
}
