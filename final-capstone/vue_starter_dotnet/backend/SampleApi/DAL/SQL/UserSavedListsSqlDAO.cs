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
        public List<Restaurant> GetFavorites(User user)
        {
            try
            {
                List<Restaurant> results = new List<Restaurant>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from Favorites where userID = @userID");
                    cmd.Parameters.AddWithValue("@userID", user.Id);
                    conn.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while(data.Read())
                    {
                        Restaurant restaurant = new Restaurant()
                        {
                            RestaurantID = Convert.ToString(data["restaurant_id"])
                            // TODO: get rest of restaurant information from API
                        };
                        results.Add(restaurant);
                    }
                    return results;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void AddFavorite(User user, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Favorites (restaurant_id) VALUES (@ri) WHERE user_id = @ui;", conn);
                    cmd.Parameters.AddWithValue("@ri", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@ui", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void RemoveFavorite(User user, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("REMOVE FROM Favorites (restaurant_id) VALUES (@ri) WHERE user_id = @ui;", conn);
                    cmd.Parameters.AddWithValue("@ri", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@ui", user.Id);

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
        public List<Restaurant> GetBlacklist(User user)
        {
            throw new NotImplementedException();
        }

        public void AddBlacklist(User user, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Blacklist (restaurant_id) VALUES (@ri) WHERE user_id = @ui;", conn);
                    cmd.Parameters.AddWithValue("@ri", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@ui", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void RemoveBlacklist(User user, Restaurant restaurant)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Blacklist (restaurant_id) VALUES (@ri) WHERE user_id = @ui;", conn);
                    cmd.Parameters.AddWithValue("@ri", restaurant.RestaurantID);
                    cmd.Parameters.AddWithValue("@ui", user.Id);

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
        private User MapRowToUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = Convert.ToInt32(reader["id"]),
                Username = Convert.ToString(reader["username"]),
                Password = Convert.ToString(reader["password"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["role"])
            };
        }
        #endregion
    }
}
