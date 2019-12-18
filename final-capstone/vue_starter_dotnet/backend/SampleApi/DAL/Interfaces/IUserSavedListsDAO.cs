using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL.Interfaces
{
    public interface IUserSavedListsDAO
    {
        #region Favorites List
        /// <summary>
        /// Returns a list of the user's favorited restaurants.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Restaurant> GetFavorites(int userId);
        /// <summary>
        /// Adds a restaurant to the database of user favorites.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void AddFavorite(int userId, Restaurant restaurant);
        /// <summary>
        /// Removes a favorite from the database of the user's favorites.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void RemoveFavorite(int userId, Restaurant restaurant);
        #endregion

        #region Blacklist
        /// <summary>
        /// Returns a list of user's blacklisted restaurants from the database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Restaurant> GetBlacklist(int userId);
        /// <summary>
        /// Adds a restaurant to the user's blacklist in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void AddBlacklist(int userId, Restaurant restaurant);
        /// <summary>
        /// Removes a restaurant from the user's blacklist in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="restaurant"></param>
        void RemoveBlacklist(int userId, Restaurant restaurant);
        #endregion

        #region Likes and Dislikes
        void Swiped(int userId, Restaurant restaurant, bool swipedRight);

        void ClearUserSwipes(int userId);

        List<Restaurant> GetSwipedRestaurants(int userId);
        #endregion
    }
}
