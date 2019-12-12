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
        /// <param name="prefs">An object containing the user's preference settings from login.</param>
        /// <returns></returns>
        List<Restaurant> GetRestaurants(Preferences prefs);

        /// <summary>
        /// Given a list of restaurant ids, returns all their info from the API.
        /// </summary>
        /// <param name="restaurants">List of restaurant IDs.</param>
        /// <returns></returns>
        Restaurant GetSpecificRestaurants(int id);

        List<Restaurant> GetFilteredRestaurantsByCuisine(string cuisine);

    }
}
