namespace Monday.Client.Mutations
{
    /// <summary>
    ///     Create a new update mutation.
    /// </summary>
    public class CreateUpdate
    {
        /// <summary>
        ///     The item's unique identifier.
        /// </summary>
        public long ItemId { get; set; }

        /// <summary>
        ///     The update text.
        /// </summary>
        public string Body { get; set; }
    }
}