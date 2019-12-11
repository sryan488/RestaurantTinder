using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user's id.
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>        
        public string Username { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The user's salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// The user's role.
        /// </summary>
        public string Role { get; set; }

        // TODO: remove below properties and add userID to property objects
        /// <summary>
        /// User preferences set at login.
        /// </summary>
        public Preferences Preferences { get; set; }

        /// <summary>
        /// List of favorited Restaurant IDs.
        /// </summary>
        public List<int> Favorites { get; set; }

        /// <summary>
        /// List of blacklisted Restaurant IDs.
        /// </summary>
        public List<int> Blacklist { get; set; }

        /// <summary>
        /// Contains restaurant ids and whether the user liked (true) or disliked (false) the restaurant.
        /// </summary>
        public Dictionary<int, bool> LikesAndDislikes { get; set; } = new Dictionary<int, bool>() {};
    }
}
