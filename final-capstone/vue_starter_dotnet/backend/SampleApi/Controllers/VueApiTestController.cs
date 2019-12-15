﻿using System;
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
        private IPreferencesDAO prefDAO;
        private IUserDAO userDAO;
        private IPasswordHasher passwordHasher;
        private IRestaurantDAO yelpDAO;

        public VueApiTestController(IPreferencesDAO dao, IUserDAO userDao, IPasswordHasher passwordHasher, IRestaurantDAO yelpDAO)
        {
            this.prefDAO = dao;
            this.userDAO = userDao;
            this.yelpDAO = yelpDAO;
            this.passwordHasher = passwordHasher;
        }


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

        [HttpGet("GetRestaurants")]
        public List<Restaurant> GetRestaurants() // placeholder, may need diff controllers
        {
            int user_id = GetCurrentUserId();
            Preferences prefs = prefDAO.GetUserPrefs(user_id);

            // Perform the search and return the results as json
            return yelpDAO.GetRestaurants(prefs);
        }

        private int GetCurrentUserId()
        {
            return userDAO.GetUser(base.User.Identity.Name).Id;
        }
    }
}