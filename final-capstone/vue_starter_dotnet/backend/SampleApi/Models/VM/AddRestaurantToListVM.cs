using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models.VM
{
    public class AddRestaurantToListVM
    {
        /// <summary>
        /// The restaurant id.
        /// </summary>
        public int RestaurantID { get; set; }

        /// <summary>
        /// The user's id.
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// True for fav or false for blacklist
        /// </summary>
        public Boolean favOrBlack { get; set; }

        public User User { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
