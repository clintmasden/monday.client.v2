using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    public class Update
    {
        /// <summary>
        ///     The update's unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The update's item unique identifier.
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemId { get; set; }

        /// <summary>
        ///     The unique identifier of the update creator.
        /// </summary>
        [JsonProperty("creator_id")]
        public int UserId { get; set; }

        /// <summary>
        ///     The update's creator.
        /// </summary>
        [JsonProperty("creator")]
        public User User { get; set; }

        /// <summary>
        ///     The update's html formatted body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     The update's text body.
        /// </summary>
        [JsonProperty("text_body")]
        public string BodyText { get; set; }

        /// <summary>
        ///     The update's replies.
        /// </summary>
        public List<Reply> Replies { get; set; }

        /// <summary>
        ///     The update's creation date.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     The update's last edit date.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}