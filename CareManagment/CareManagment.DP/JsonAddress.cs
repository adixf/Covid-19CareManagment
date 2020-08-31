using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP
{
    public class JsonAddress
    {
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Id { get; set; }
        public string Osm_id { get; set; }
        public string Osm_type { get; set; }
        public List<string> Bondingbox { get; set; }
    }
}
