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
                    SqlCommand cmd = new SqlCommand("select * from preferences", conn);

                    conn.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while(data.Read())
                    {
                        Preferences pref = new Preferences()
                        {
                            UserID = Convert.ToInt32(data["users_id"]),
                            SearchCategories = DeserializeSearchText(Convert.ToString(data["cuisine"])),
                            //PriceRange = DeserializePrices(Convert.ToString(data["price"])),
                            Location = Convert.ToString(data["city"]),
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from preferences where users_id = @userID", conn);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    conn.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Preferences pref = new Preferences()
                        {
                            UserID = Convert.ToInt32(data["users_id"]),
                            SearchText = Convert.ToString(data["searchText"]),
                            SearchCategories = DeserializeSearchText(Convert.ToString(data["searchText"])),
                            MaxPriceRange = Convert.ToInt32(data["price"]),
                            Location = Convert.ToString(data["location"]),
                            SearchRadius = Convert.ToDouble(data["radius"])
                        };
                        return pref;
                    }
                    throw new Exception("No preferences found for user."); // if no user found;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        public void SetUserPrefs(int userID, Preferences preferences)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string searchText = preferences.SearchText;
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE preferences
                                                      SET searchText = @searchText, price = @price_range, location = @location, radius = @radius
                                                      WHERE users_id = @ui;", conn);
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    cmd.Parameters.AddWithValue("@price_range", preferences.MaxPriceRange);
                    cmd.Parameters.AddWithValue("@location", preferences.Location);
                    cmd.Parameters.AddWithValue("@radius", preferences.SearchRadius);
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
        private List<string> DeserializeSearchText(string searchText)
        {
            return searchText.Split(',').ToList<string>();
        }
        #endregion

    }
}
