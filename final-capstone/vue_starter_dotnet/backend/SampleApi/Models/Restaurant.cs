using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Restaurant Model
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Restaurant()
        {

        }
        /// <summary>
        /// Constructor that takes user's current latitude and longitude to get the distance to the restaurant.
        /// </summary>
        /// <param name="userLatitude"></param>
        /// <param name="userLongitude"></param>
        public Restaurant(double userLatitude, double userLongitude)
        {
            /// set distance based on user location
        }

        /// <summary>
        /// The restaurant id.
        /// </summary>
        public string RestaurantID { get; set; }

        /// <summary>
        /// The name of the restaurant.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The street address of the restaurant.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city of the restaurant.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The state of the restaurant.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The zip code of the restaurant.
        /// </summary>
        public string ZIP { get; set; }

        /// <summary>
        /// The categories (e.g. seafood, italian, chinese) of the restaurant's cuisine.
        /// </summary>
        public List<string> Categories { get; set; } // cuisine

        /// <summary>
        /// The price range of the restaurant. Scale of 1-4, 1 being cheapest, 4 being most expensive.
        /// </summary>
        public int MaxPriceRange { get; set; }

        /// <summary>
        /// The distance from the given position.
        /// </summary>
        public double Distance { get; set; } // in miles

        public string ImgUrl { get; set; }

        public bool Liked { get; set; }
    }
}
