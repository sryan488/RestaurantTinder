using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL.Interfaces
{
    public interface IPreferencesDAO
    {
        /// <summary>
        /// Gets all preferences in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Preferences> GetAllPrefs();

        /// <summary>
        /// Gets the preferences of a single user by ID.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        Preferences GetUserPrefs(int userID);

        /// <summary>
        /// Sets the user's saved preferences in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="preferences"></param>
        void SetUserPrefs(int userID, Preferences preferences);
    }
}
