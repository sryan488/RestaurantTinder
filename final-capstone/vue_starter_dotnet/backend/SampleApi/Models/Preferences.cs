using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Preferences
    {

        public List<string> Categories { get; set; }

        public int PriceRange { get; set; }

        public string City { get; set; }

        public double SearchRadius { get; set; } // distance in miles

    }
}
