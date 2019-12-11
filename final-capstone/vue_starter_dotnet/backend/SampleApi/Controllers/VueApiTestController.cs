using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApi.DAL;
using SampleApi.DAL.Interfaces;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class VueApiTestController : ControllerBase
    {
        IPreferencesDAO DAO;
        public VueApiTestController(IPreferencesDAO dao)
        {
            DAO = dao;
        }

        [HttpGet]
        public List<Preferences> GetAllPreferences()
        {
            return DAO.GetAllPrefs();
        }

        [HttpGet("{id}")]
        public Preferences GetUserPreferences(int id)
        {
            return DAO.GetUserPrefs(id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Preferences newPrefs)
        {
            if (DAO.GetUserPrefs(id) == null)
            {
                return NotFound();
            }
            DAO.SetUserPrefs(id, newPrefs);
            return NoContent();
        }
    }
}