using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     Monday.com items are another core object in the platform. Items are the objects that hold the actual data within
    ///     the board, to better illustrate this, you can think of a board as a table and a item as a single row in that table.
    /// </summary>
    public class Item
    {
        /// <summary>
        ///     The item's unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The board that contains this item.
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        ///     The group that contains this item.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        ///     The item's column values.
        /// </summary>
        [JsonProperty("column_values")]
        public List<ColumnValue> ColumnValues { get; set; }

        /// <summary>
        ///     The unique identifier of the item creator.
        /// </summary>
        [JsonProperty("creator_id")]
        public int UserId { get; set; }

        /// <summary>
        ///     The item's creator.
        /// </summary>
        [JsonProperty("creator")]
        public User User { get; set; }

        /// <summary>
        ///     The item's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The item's subscribers.
        /// </summary>
        public List<User> Subscribers { get; set; }

        /// <summary>
        ///     Monday - Why is everything else a real DateTime except on pulses/items /sigh
        /// </summary>
        [JsonProperty("created_at")]
        internal string CreatedAtString { get; set; }

        /// <summary>
        ///     The item's create date [LocalDateTime].
        /// </summary>
        public DateTime? CreatedAt => !string.IsNullOrWhiteSpace(CreatedAtString) ? (DateTime?) DateTimeOffset.Parse(CreatedAtString.Replace("UTC", string.Empty)).LocalDateTime : null;

        /// <summary>
        ///     Monday - Why is everything else a real DateTime except on pulses/items /sigh
        /// </summary>
        [JsonProperty("updated_at")]
        internal string UpdatedAtString { get; set; }

        /// <summary>
        ///     The item's last update date [LocalDateTime].
        /// </summary>
        public DateTime? UpdatedAt => !string.IsNullOrWhiteSpace(UpdatedAtString) ? (DateTime?) DateTimeOffset.Parse(UpdatedAtString.Replace("UTC", string.Empty)).LocalDateTime : null;
    }
}