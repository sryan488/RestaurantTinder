using SampleApi.DAL.Interfaces;
using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL.SQL
{
    public class PreferencesSqlDAO : IPreferencesDAO
    {
        private readonly string connectionString;
        public PreferencesSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Preferences> GetAllPrefs()
        {
            try
            {
                List<Preferences> results = new List<Preferences>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from preferences");

                    SqlDataReader data = cmd.ExecuteReader();
                    conn.Open();
                    while(data.Read())
                    {
                        Preferences pref = new Preferences()
                        {
                            UserID = Convert.ToInt32(data["user_id"]),
                            // TODO: parse category SQL string into a list of strings
                            cuisineCategoryString = 
                            // TODO: parse price range into list
                            City = Convert.ToString(data["city"]),
                            SearchRadius = Convert.ToDouble(data["distance"])
                        };
                        results.Add(pref);
                    }
                    return results;
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public Preferences GetUserPrefs(int userID)
        {
            throw new NotImplementedException();
        }

        public void SetUserPrefs(int userID, Preferences preferences)
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
                    cmd.Parameters.AddWithValue("@ui", userID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        #region Internal functions
        //private Preferences MapRowToPreferences(SqlDataReader reader) => new Preferences()
        //{
        //    Categories = Convert.ToList(reader["categories"]),
        //    PriceRange = Convert.ToInt32(reader["price_range"]),
        //    City = Convert.ToString(reader["city"]),
        //    SearchRadius = Convert.ToDouble(reader["search_radius"])
        //};
        #endregion

    }
}
