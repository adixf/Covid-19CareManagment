using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class Address
    {

        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Address(string City, string Street, int BuildingNumber)
        {
            this.City = City;
            this.Street = Street;
            this.BuildingNumber = BuildingNumber;
        }

        public Address(Address address)
        {
            City = address.City;
            Street = address.Street;
            BuildingNumber = address.BuildingNumber;
        }
        public Address()
        {
          
        }
        public override string  ToString()
        {
            return Street + " " + BuildingNumber + " " + City;
        }
    }
}
