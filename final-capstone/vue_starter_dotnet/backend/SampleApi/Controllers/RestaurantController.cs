﻿using System;
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

        public IRestResponse GetData()
        {
            var client = new RestClient("https://api.yelp.com/v3/businesses/search?location=lyndhurst%20oh&radius=2000&categories=pizza,mexican&price=1,2,3");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", "api.yelp.com");
            request.AddHeader("Postman-Token", "5d284b5b-a64a-41d0-98df-313efc0cb9cc,94fe6714-6483-43e7-a727-9bf30cda8b0c");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("User-Agent", "PostmanRuntime/7.20.1");
            request.AddHeader("Authorization", "Bearer VESkUp-nJuneNqJhU6yLt7nGSYN29do8SXv9GNJ-Dbvp-qSd5kShcFZZFYJEUvqMWMLXcV6sz1SK21vU_yQMXMoSSLnCARVqC0O_f28r91H9YVf01169JkFVmI3uXXYx");
            IRestResponse response = client.Execute(request);

            return response;
        }

    }
}