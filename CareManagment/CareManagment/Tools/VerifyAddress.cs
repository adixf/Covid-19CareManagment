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
            if (AddressDetails == null)
                return false;
            return AddressDetails.DisplayName.Contains(address.Street) && AddressDetails.DisplayName.Contains(address.City);
        }

        public double[] GetLocation(Address address)
        {
            JsonAddress AddressDetails = new BLImp().GetAddressDetails(address);
            double lat = Convert.ToDouble(AddressDetails.Latitude);
            double lon = Convert.ToDouble(AddressDetails.Longitude);
            double[] location = new double[2] { lat, lon };
            return location;
        }

    }
}
