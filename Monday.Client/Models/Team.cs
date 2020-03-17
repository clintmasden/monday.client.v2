using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     Teams are the most efficient way to manage groups of users in monday.com. Teams are comprised of one or multiple
    ///     users, and every user can be a part of multiple teams (or none).
    /// </summary>
    public class Team
    {
        /// <summary>
        ///     The team's unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The team's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The team's picture url.
        /// </summary>
        [JsonProperty("photo_url")]
        public string Photo { get; set; }

        /// <summary>
        ///     The users in the team.
        /// </summary>
        public List<User> Users { get; set; }
    }
}