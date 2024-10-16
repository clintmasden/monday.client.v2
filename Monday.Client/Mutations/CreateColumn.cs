using Monday.Client.Models;

namespace Monday.Client.Mutations
{
    /// <summary>
    ///     Create a new column in board mutation.
    /// </summary>
    public class CreateColumn
    {
        /// <summary>
        ///     The board's unique identifier.
        /// </summary>
        public string BoardId { get; set; }

        /// <summary>
        ///     The new column's title.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The type of column to create.
        /// </summary>
        public ColumnTypes ColumnType { get; set; }

        /// <summary>
        ///     The new column's defaults. [JSON]
        /// </summary>
        public string Defaults { get; set; }
    }
}