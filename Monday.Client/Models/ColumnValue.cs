using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     The value of an items column
    /// </summary>
    public class ColumnValue
    {
        /// <summary>
        ///     The column's unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The column's title.
        /// </summary>
        [JsonProperty("title")]
        public string Name { get; set; }

        /// <summary>
        ///     The column's value in json format.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        ///     The column's textual value in string form.
        /// </summary>
        [JsonProperty("text")]
        public string ValueText { get; set; }

        /// <summary>
        ///     The column value's additional information. [JSON]
        /// </summary>
        [JsonProperty("additional_info")]
        public string Information { get; set; }
    }
}