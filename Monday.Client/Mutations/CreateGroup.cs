namespace Monday.Client.Mutations
{
    /// <summary>
    ///     Creates a new group in a specific board mutation.
    /// </summary>
    public class CreateGroup
    {
        /// <summary>
        ///     The board's unique identifier.
        /// </summary>
        public string BoardId { get; set; }

        /// <summary>
        ///     The name of the new group.
        /// </summary>
        public string Name { get; set; }
    }
}