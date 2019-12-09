using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// An interface for user data objects.
    /// </summary>
    public interface IUserDAO
    {
        /// <summary>
        /// Retrieves a user from the system by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user"></param>
        void CreateUser(User user);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);

        /// <summary>
        /// Returns a list of the user's favorited restaurants.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Restaurant> GetFavorites(User user);

        /// <summary>
        /// Adds a restaurant to the database of user favorites.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void AddFavorite(User user, Restaurant restaurant);

        /// <summary>
        /// Removes a favorite from the database of the user's favorites.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void RemoveFavorite(User user, Restaurant restaurant);

        /// <summary>
        /// Returns a list of user's blacklisted restaurants from the database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Restaurant> GetBlacklist(User user);

        /// <summary>
        /// Adds a restaurant to the user's blacklist in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void AddBlacklist(User user, Restaurant restaurant);

        /// <summary>
        /// Removes a restaurant from the user's blacklist in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void RemoveBlacklist(User user, Restaurant restaurant);

        /// <summary>
        /// Gets a preference object from the user's saved preferences in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Preferences GetPreferences(User user);

        /// <summary>
        /// Sets the user's saved preferences in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="preferences"></param>
        void SetPreferences(User user, Preferences preferences);

    }
}
