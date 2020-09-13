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
            // var AddressDetails = new BLImp().GetAddressDetails(address);
            // return AddressDetails.Result.Description.Contains(address.Street) && AddressDetails.Result.Description.Contains(address.City);
            return true;
        }
        

    }
}
