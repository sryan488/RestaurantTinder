using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL.Interfaces
{
    public interface IUserSavedLists
    {
        #region Favorites List
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
        #endregion

        #region Blacklist
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
        #endregion
    }
}
