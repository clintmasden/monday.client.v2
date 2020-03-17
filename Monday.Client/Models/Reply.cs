using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     A reply for an update.
    /// </summary>
    public class Reply
    {
        /// <summary>
        ///     The reply's unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The unique identifier of the reply creator.
        /// </summary>
        [JsonProperty("creator_id")]
        public int UserId { get; set; }

        /// <summary>
        ///     The reply's creator.
        /// </summary>
        [JsonProperty("creator")]
        public User User { get; set; }

        /// <summary>
        ///     The reply's html formatted body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     The reply's text body.
        /// </summary>
        [JsonProperty("text_body")]
        public string BodyText { get; set; }

        public List<Reply> Replies { get; set; }

        /// <summary>
        ///     The reply's creation date.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     The reply's last edit date.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}