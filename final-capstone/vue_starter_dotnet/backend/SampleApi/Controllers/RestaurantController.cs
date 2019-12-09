using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

       private MockRestaurantDAO Rdao;
        private UserSqlDAO Udao;

        public RestaurantController(MockRestaurantDAO Rdao, UserSqlDAO Udao)
        {
            this.Rdao = Rdao;
            this.Udao = Udao;
        }

        /// <summary>
        /// Returns all product reviews.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{username}", Name = "GetRestaurantsById")]
        public ActionResult<List<Restaurant>> GetFilteredRestaurants(string username)
        {
            //User user = Udao.GetUser(username);
            User user = new User()
            {
                Id = 12345,
                Username = "sam1776",
            };
            Preferences pref = Udao.GetPreferences(user);
            List<Restaurant> restaurants = Rdao.GetFilteredRestaurants(pref);

            // Return 200 OK
            return Ok(restaurants);
        }
    }
}