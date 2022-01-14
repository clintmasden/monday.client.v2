namespace Monday.Client.Mutations
{
    /// <summary>
    ///     Create a new item mutation.
    /// </summary>
    public class CreateItem
    {
        /// <summary>
        ///     The new item's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The board's unique identifier.
        /// </summary>
        public long BoardId { get; set; }

        /// <summary>
        ///     The group's unique identifier.
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        ///     The column values of the new item [JSON].
        /// </summary>
        public string ColumnValues { get; set; }
    }
}