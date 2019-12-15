﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;
using Yelp;
using Yelp.Api.Models;

namespace SampleApi.DAL.YelpAPI
{
    public class RestaurantApiDAO : IRestaurantDAO
    {
        private string ApiKey;
        public RestaurantApiDAO(string apiKey)
        {
            ApiKey = apiKey;
        }

        public List<Restaurant> GetRestaurants(Preferences prefs)
        {
            var task = Search(prefs);
            var results = task.Result.Businesses;

            List<Restaurant> restaurantList = new List<Restaurant>();
            foreach(BusinessResponse restaurant in results)
            {
                restaurantList.Add(new Restaurant()
                {
                    RestaurantID = restaurant.Id,
                    Name = restaurant.Name,
                    // TODO: Location parsing
                    Categories = GetSearchResultCategories(restaurant.Categories),
                    MaxPriceRange = GetMaxPrice(restaurant.Price),
                    Distance = (double)restaurant.Distance
                });
            }

            return restaurantList;
        }

        public List<Restaurant> GetFilteredRestaurantsByCuisine(string cuisine)
        {
            throw new NotImplementedException();
        }
        public Restaurant GetSpecificRestaurants(int id)
        {
            throw new NotImplementedException();
        }

        #region Internal Functions
        async private Task<Yelp.Api.Models.SearchResponse> Search(Preferences prefs)
        {
            // Connect to the Yelp API
            Yelp.Api.Client client = new Yelp.Api.Client(ApiKey);
            Yelp.Api.Models.SearchRequest request = new Yelp.Api.Models.SearchRequest();

            // Fill in the search parameters
            #region Search Parameters
            request.Location = prefs.Location;
            request.Term = GetSearchCategoryString(prefs.Categories);
            request.Categories = "food";
            switch (prefs.MaxPriceRange)
            {
                case 1:
                    request.Price = "1";
                    break;
                case 2:
                    request.Price = "1, 2";
                    break;
                case 3:
                    request.Price = "1, 2, 3";
                    break;
                case 4:
                    request.Price = "1, 2, 3, 4";
                    break;
                default:
                    request.Price = "1, 2, 3, 4";
                    break;
            }
            request.Radius = (int)Math.Round((prefs.SearchRadius / 1609.34), 0);
            #endregion

            // Run the search and return the results
            Yelp.Api.Models.SearchResponse results = await client.SearchBusinessesAllAsync(request);
            return results;
        }
        private string GetSearchCategoryString(List<string> categories)
        {
            string resultString = categories[0];
            for (int i=1; i<categories.Count; i++)
            {
                resultString += ", " + categories[i];
            }
            return resultString;
        }
        private int GetMaxPrice(string prices)
        {
            List<string> priceList = prices.Split(',').ToList<string>();
            List<int> priceInts = new List<int>();
            foreach (string price in priceList)
            {
                priceInts.Add(Int32.Parse(price));
            }
            return priceInts.Max();
        }
        private List<string> GetSearchResultCategories(Category[] categories)
        {
            if (categories.Length == 0)
            {
                return new List<string>() { "None" };
            }
            var result = new List<string>() { categories[0].Title };
            for (int i=1; i<categories.Length; i++)
            {
                result.Add(categories[i].Title);
            }
            return result;
        }
        #endregion

    }
}
