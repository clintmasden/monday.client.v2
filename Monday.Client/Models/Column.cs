using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     Columns and items are two core elements of a board. A board is formatted as a table where there are columns and
    ///     rows called items. In monday.com each column has a specific functionality it enables (ex. a numbers column, a text
    ///     column, a time tracking column, etc.)
    /// </summary>
    public class Column
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

        [JsonProperty("type")] public string Type { get; set; }

        ///// <summary>
        ///// The column's type.
        ///// </summary>
        //public ColumnTypes ColumnType => Enum.TryParse(Type.FirstCharacterToUpper(), out ColumnTypes type) ? type : ColumnTypes.Default;

        /// <summary>
        ///     Is the column archived.
        /// </summary>
        [JsonProperty("archived")]
        public bool IsArchived { get; set; }

        /// <summary>
        ///     The column's settings in a string form.
        /// </summary>
        [JsonProperty("settings_str")]
        public string Settings { get; set; }
    }
}