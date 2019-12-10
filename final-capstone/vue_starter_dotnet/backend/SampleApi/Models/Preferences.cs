using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Preferences
    {
        public int UserID { get; set; }

        public List<string> Categories { get; set; }

        public List<int> PriceRange { get; set; }

        public string City { get; set; }

        public double SearchRadius { get; set; } // distance in miles

    }
}
