using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;
using SampleApi.Models.VM;

namespace SampleApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

       private IRestaurantDAO Rdao;
        private IUserDAO Udao;

        public RestaurantController(IRestaurantDAO Rdao, IUserDAO Udao)
        {
            this.Rdao = Rdao;
            this.Udao = Udao;
        }

        /// <summary>
        /// Returns list of restaurants for a customer
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

        /// <summary>
        /// Remove from blacklist, whitelist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var article = dal.GetArticle(id);

        //    if (article == null)
        //    {
        //        // return HTTP 404
        //        return NotFound();
        //    }

        //    // delete the resource
        //    dal.DeleteArticle(id);

        //    // return HTTP 201
        //    return NoContent();
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="user"></param>
        /// <param name="favOrBlack"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<AddRestaurantToListVM> AddRestaurantToList([FromBody]AddRestaurantToListVM aRTLVM)
        {
            
            User user = aRTLVM.User;
            Restaurant restaurant = aRTLVM.Restaurant;
            // Save in the dao
            if (aRTLVM.favOrBlack)
            {
                Udao.AddFavorite(user, restaurant);
            }
            else
            {
                Udao.AddBlacklist(user, restaurant);
            }
            

            // Return 201 (with a location header: https://localhost:44359/api/reviews/{id})
            // First parameter - Name of the route to generate for API
            // Second parameter - The variables for the route
            // Third parameter - The response body
            return CreatedAtRoute("AddRestaurantToList", new { id = aRTLVM.Id }, aRTLVM);
        }
    }
}