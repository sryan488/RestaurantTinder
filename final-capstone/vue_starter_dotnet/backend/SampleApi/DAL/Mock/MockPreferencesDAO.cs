using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    public class MockPreferencesDAO
    {
        List<Preferences> PrefsList = new List<Preferences>()
        {
            new Preferences()
            {
                UserID = 1,
                Categories = new List<string>() { "French", "Seafood" },
                MaxPriceRange = 3,
                Location = "Paris",
                SearchRadius = 25
            },
            new Preferences()
            {
                UserID = 2,
                Categories = new List<string>() { "Italian", "Pizza" },
                MaxPriceRange = 3,
                Location = "Cleveland",
                SearchRadius = 10
            },
            new Preferences()
            {
                UserID = 3,
                Categories = new List<string>() { "Chinese", "Takeout" },
                MaxPriceRange =  1,
                Location = "Chicago",
                SearchRadius = 50
            }
        };

        public List<Preferences> GetAllPreferences()
        {
            return PrefsList;
        }

        public Preferences GetPrefsOfUser(int id)
        {
            Preferences result = (from pref in PrefsList
                                  where (pref.UserID == id)
                                  select pref).ToList<Preferences>()[0];
            return result;
        }

        public void SetUserPrefs(int id, Preferences newPrefs)
        {
            Preferences oldPrefs = (from prefs in PrefsList
                                    where prefs.UserID == id
                                    select prefs).ToList<Preferences>()[0];
            oldPrefs = newPrefs;
        }
    }
}
