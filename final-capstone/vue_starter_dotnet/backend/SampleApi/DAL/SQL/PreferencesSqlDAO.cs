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
                            Categories = DeserializeCategories(Convert.ToString(data["cuisine"])),
                            PriceRange = DeserializePrices(Convert.ToString(data["price"])),
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
        private List<string> DeserializeCategories(string categoryString)
        {
            return categoryString.Split(',').ToList<string>();
        }
        private List<int> DeserializePrices(string prices)
        {
            List<string> list = prices.Split(',').ToList<string>();
            List<int> results = new List<int>();
            foreach(string str in list)
            {
                results.Add(Convert.ToInt32(str));
            }
            return results;
        }
        #endregion

    }
}
