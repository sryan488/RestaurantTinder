using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

namespace SampleApi.DAL
{
    public class MockRestaurantDAO : IRestaurantDAO
    {
        string connString;
        List<Restaurant> restaurants;
        public MockRestaurantDAO(string connString)
        {
            this.connString = connString;
            this.restaurants = new List<Restaurant> restaurants{

            };


        }

        public List<Restaurant> GetFilteredRestaurants(Preferences prefs)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetSpecificRestaurants(List<int> restaurants)
        {
            throw new NotImplementedException();
        }
    }
}
