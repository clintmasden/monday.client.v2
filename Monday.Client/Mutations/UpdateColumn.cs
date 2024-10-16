namespace Monday.Client.Mutations
{
    /// <summary>
    ///     Change an item's column value mutation.
    /// </summary>
    public class UpdateColumn
    {
        /// <summary>
        ///     The board's unique identifier.
        /// </summary>
        public string BoardId { get; set; }

        /// <summary>
        ///     The item's unique identifier.
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        ///     The column's unique identifier.
        /// </summary>
        public string ColumnId { get; set; }

        /// <summary>
        ///     The new value of the column. [JSON] [https://monday.com/developers/v2#column-values-section]
        /// </summary>
        public string Value { get; set; }
    }
}