using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

namespace SampleApi.DAL
{
    /// <summary>
    /// A SQL Dao for user objects.
    /// </summary>
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public UserSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
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

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES (@username, @password, @salt, @role);", conn);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the user from the database.
        /// </summary>
        /// <param name="user"></param>
        public void DeleteUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", user.Id);                    

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Restaurant> GetBlacklist(User user)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetFavorites(User user)
        {
            throw new NotImplementedException();
        }

        public Preferences GetPreferences(User user)
        {
            Preferences prefs = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Preferences WHERE userId = @uid;", conn);
                    cmd.Parameters.AddWithValue("@uid", user.Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToPreferences(reader);
                    }
                }

                return prefs;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the user from the database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            User user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE username = @username;", conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        user = MapRowToUser(reader);
                    }
                }

                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
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

        public void SetPreferences(User user, Preferences preferences)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Preferences (cuisine, price_range, city, search_radius) VALUES (@cuisine, @price_range, @city, @search_radius) WHERE userId = @ui;", conn);
                    cmd.Parameters.AddWithValue("@cuisine", preferences.Categories);
                    cmd.Parameters.AddWithValue("@price_range", preferences.PriceRange);
                    cmd.Parameters.AddWithValue("@city", preferences.City);
                    cmd.Parameters.AddWithValue("@search_radius", preferences.SearchRadius);
                    cmd.Parameters.AddWithValue("@ui", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the user in the database.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users SET password = @password, salt = @salt, role = @role WHERE id = @id;", conn);                    
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@id", user.Id);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

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

        private Preferences MapRowToPreferences(SqlDataReader reader) => new Preferences()
        {
            Categories = Convert.ToList(reader["categories"]),
            PriceRange = Convert.ToInt32(reader["price_range"]),
            City = Convert.ToString(reader["city"]),
            SearchRadius = Convert.ToDouble(reader["search_radius"])
        };

    }
}