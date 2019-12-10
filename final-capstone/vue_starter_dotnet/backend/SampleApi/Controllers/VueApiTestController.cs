using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class VueApiTestController : ControllerBase
    {
        MockPreferencesDAO DAO = new MockPreferencesDAO();

        [HttpGet]
        public List<Preferences> GetAllPrefs()
        {
            return DAO.GetAllPreferences();
        }

        [HttpGet("{id}")]
        public Preferences GetUserPrefs(int id)
        {
            return DAO.GetPrefsOfUser(id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Preferences newPrefs)
        {
            if (DAO.GetPrefsOfUser(id) == null)
            {
                return NotFound();
            }
            DAO.SetUserPrefs(id, newPrefs);
            return NoContent();
        }
    }
}