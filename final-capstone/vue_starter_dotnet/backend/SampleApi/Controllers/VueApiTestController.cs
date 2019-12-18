using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApi.DAL;
using SampleApi.DAL.Interfaces;
using SampleApi.Models;
using SampleApi.Providers.Security;

namespace SampleApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class VueApiTestController : ControllerBase
    {
        #region Constructor & DAOs
        private IPreferencesDAO prefDAO;
        private IUserDAO userDAO;
        private IUserSavedListsDAO listsDAO;
        private IPasswordHasher passwordHasher;
        private IRestaurantDAO yelpDAO;

        public VueApiTestController(IPreferencesDAO dao, IUserDAO userDao, IUserSavedListsDAO listsDAO, IPasswordHasher passwordHasher, IRestaurantDAO yelpDAO)
        {
            this.prefDAO = dao;
            this.userDAO = userDao;
            this.yelpDAO = yelpDAO;
            this.listsDAO = listsDAO;
            this.passwordHasher = passwordHasher;
        }
        #endregion

        #region Preferences
        [HttpGet]
        public Preferences GetUserPreferences()
        {
            int id = GetCurrentUserId();
            return prefDAO.GetUserPrefs(id);
        }

        [HttpPut]
        public ActionResult Update(Preferences newPrefs)
        {
            int id = GetCurrentUserId();
            if (prefDAO.GetUserPrefs(id) == null)
            {
                return NotFound(); 
            }
            prefDAO.SetUserPrefs(id, newPrefs);
            return NoContent();
        }
        #endregion

        #region Swipes
        [HttpPost("SwipeLeft")]
        public ActionResult SwipeLeft(Restaurant restaurant)
        {
            int user_id = GetCurrentUserId();
            listsDAO.Swiped(user_id, restaurant, false);
            return Ok();
        }
        [HttpPost("SwipeRight")]
        public ActionResult SwipeRight(Restaurant restaurant)
        {
            int user_id = GetCurrentUserId();
            listsDAO.Swiped(user_id, restaurant, true);
            return Ok();
        }
        [HttpDelete("ClearSwipes")]
        public ActionResult ClearSwipes()
        {
            int user_id = GetCurrentUserId();
            listsDAO.ClearUserSwipes(user_id);
            return NoContent();
        }
        [HttpGet("GetSwipes")]
        public ActionResult<List<Restaurant>> GetSwipes()
        {
            int user_id = GetCurrentUserId();
            return listsDAO.GetSwipedRestaurants(user_id);
        }
        #endregion

        #region Favorites
        [HttpGet("GetFavorites")]
        public List<Restaurant> GetFavorites()
        {
            int user_id = GetCurrentUserId();
            return listsDAO.GetFavorites(user_id);
        }
        [HttpPost("AddFavorite")]
        public ActionResult AddFavorite(Restaurant restaurant)
        {
            int user_id = GetCurrentUserId();
            listsDAO.AddFavorite(user_id, restaurant);
            return StatusCode(201); // Created
        }
        [HttpDelete("RemoveFavorite")]
        public ActionResult RemoveFavorite(Restaurant restaurant)
        {
            int user_id = GetCurrentUserId();
            listsDAO.RemoveFavorite(user_id, restaurant);
            return NoContent();
        }
        #endregion

        #region Blacklist
        [HttpGet("GetBlacklist")]
        public List<Restaurant> GetBlacklist()
        {
            int user_id = GetCurrentUserId();
            return listsDAO.GetBlacklist(user_id);
        }
        [HttpPost("AddBlacklist")]
        public ActionResult AddBlacklist(Restaurant restaurant)
        {
            int user_id = GetCurrentUserId();
            listsDAO.AddBlacklist(user_id, restaurant);
            return StatusCode(201); // Created
        }
        [HttpDelete("RemoveBlacklist")]
        public ActionResult RemoveBlacklist(Restaurant restaurant)
        {
            int user_id = GetCurrentUserId();
            listsDAO.RemoveBlacklist(user_id, restaurant);
            return NoContent();
        }
        #endregion

        #region Yelp API Calls
        [HttpGet("GetRestaurants")]
        public ActionResult<List<Restaurant>> GetRestaurants() // placeholder, may need diff controllers
        {
            int user_id = GetCurrentUserId();
            Preferences prefs = prefDAO.GetUserPrefs(user_id);

            // Perform the search and return the results as json
            List<Restaurant> results = yelpDAO.GetRestaurants(prefs);
            if (results.Count == 0)
            {
                return NotFound(); // no results found, display the "no search results" page
            }
            else
            {
                return results;
            }
        }
        #endregion

        #region Internal Functions
        private int GetCurrentUserId()
        {
            return userDAO.GetUser(base.User.Identity.Name).Id;
        }
        #endregion
    }
}