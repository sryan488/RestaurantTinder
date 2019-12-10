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
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    RestaurantID = 1,
                    Name = "Food Place",
                    Address = "123 place",
                    City = "Cleveland",
                    State = "Ohio",
                    ZIP = "44115",
                    Categories = new List<String>() {"Cat Food", "Dog Food" },
                    PriceRange = 1,
                    Distance = 23

                },
                new Restaurant()
                {
                    RestaurantID = 2,
                    Name = "Food Place",
                    Address = "123 place",
                    City = "Cleveland",
                    State = "Ohio",
                    ZIP = "44115",
                    Categories = new List<String>() {"Cat Food", "Dog Food" },
                    PriceRange = 1,
                    Distance = 23
                },
                new Restaurant()
                {
                    RestaurantID = 3,
                    Name = "Food Place",
                    Address = "123 place",
                    City = "Cleveland",
                    State = "Ohio",
                    ZIP = "44115",
                    Categories = new List<String>() {"Cat", "Dog Food" },
                    PriceRange = 1,
                    Distance = 23
                }
            };


        }

        public List<Restaurant> GetFilteredRestaurants(Preferences prefs)
        {
            return restaurants;
        }

        public Restaurant GetSpecificRestaurants(int id)
        {
            return restaurants[id];
        }
        public List<Restaurant> GetFilteredRestaurantsByCuisine(string cuisine)
        {
            List<Restaurant> output = new List<Restaurant>();
            for(int i=0; i < restaurants.Count; i++)
            {
                if (restaurants[i].Categories.Contains(cuisine))
                {
                    output.Add(restaurants[i]);
                }
            }

            return output;
        }
    }
}
