using SampleApi.DAL.Interfaces;
using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL.SQL
{
    public class UserSavedListsSqlDAO : IUserSavedListsDAO
    {
        private readonly string connectionString;
        public UserSavedListsSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region Favorites List
        public List<Restaurant> GetFavorites(int userId)
        {
            try
            {
                List<Restaurant> results = new List<Restaurant>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from favorites where users_id = @userID", conn);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    conn.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while(data.Read())
                    {
                        results.Add(ConvertDataRowToRestaurant(data));
                    }
                    return results;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void AddFavorite(int userId, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO favorites (users_id, restaurant_id, name, address, city, state, zip, categories, img_url) 
                                                      VALUES (@userID, @restaurantID, @name, @address, @city, @state, @zip, @categories, @img)"
                        , conn);
                    cmd.Parameters.AddWithValue("@restaurantID", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@address", restaurant.Address);
                    cmd.Parameters.AddWithValue("@city", restaurant.City);
                    cmd.Parameters.AddWithValue("@state", restaurant.State);
                    cmd.Parameters.AddWithValue("@zip", restaurant.ZIP);
                    cmd.Parameters.AddWithValue("@categories", CategoriesToString(restaurant.Categories));
                    cmd.Parameters.AddWithValue("@img", restaurant.ImgUrl);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void RemoveFavorite(int userId, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM favorites WHERE (users_id = @userID AND restaurant_id = @restaurantID)", conn);
                    cmd.Parameters.AddWithValue("@restaurantID", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@userID", userId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        #endregion

        #region Blacklist
        public List<Restaurant> GetBlacklist(int userId)
        {
            try
            {
                List<Restaurant> results = new List<Restaurant>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from blacklist where users_ID = @userID", conn);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    conn.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        results.Add(ConvertDataRowToRestaurant(data));
                    }
                    return results;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void AddBlacklist(int userId, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO favorites (users_id, restaurant_id, name, address, city, state, zip, categories, img_url) 
                                                      VALUES (@userID, @restaurantID, @name, @address, @city, @state, @zip, @categories, @img)"
                        , conn);
                    cmd.Parameters.AddWithValue("@restaurantID", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@userID", userId);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@address", restaurant.Address);
                    cmd.Parameters.AddWithValue("@city", restaurant.City);
                    cmd.Parameters.AddWithValue("@state", restaurant.State);
                    cmd.Parameters.AddWithValue("@zip", restaurant.ZIP);
                    cmd.Parameters.AddWithValue("@categories", CategoriesToString(restaurant.Categories));
                    cmd.Parameters.AddWithValue("@img", restaurant.ImgUrl);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void RemoveBlacklist(int userId, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM blacklist WHERE (users_id = @userID AND restaurant_id = @restaurantID)", conn);
                    cmd.Parameters.AddWithValue("@restaurantID", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@userID", userId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        #endregion

        #region Internal functions
        private string CategoriesToString(List<string> categories)
        {
            return String.Join(',', categories);
        }
        private List<string> StringToCategories(string categories)
        {
            return categories.Split(',').ToList<string>();
        }
        private Restaurant ConvertDataRowToRestaurant(SqlDataReader data)
        {
            return new Restaurant()
            {
                RestaurantID = Convert.ToString(data["restaurant_id"]),
                Name = Convert.ToString(data["name"]),
                Address = Convert.ToString(data["address"]),
                City = Convert.ToString(data["city"]),
                State = Convert.ToString(data["state"]),
                ZIP = Convert.ToString(data["zip"]),
                Categories = StringToCategories(Convert.ToString(data["categories"])),
                ImgUrl = Convert.ToString(data["img_url"])
            };
        }
        #endregion
    }
}
