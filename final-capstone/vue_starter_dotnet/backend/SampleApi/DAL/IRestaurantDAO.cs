using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public interface IRestaurantDAO
    {
        /// <summary>
        /// Returns a list of restaurants that fit the given preferences.
        /// </summary>
        /// <param name="prefs">A preferences object containing the user preferences.</param>
        /// <returns></returns>
        List<Restaurant> GetFilteredRestaurants(Preferences prefs);


    }
}
