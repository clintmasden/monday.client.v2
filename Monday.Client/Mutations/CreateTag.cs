namespace Monday.Client.Mutations
{
    /// <summary>
    ///     Create a new tag or get it if it already exists mutation.
    /// </summary>
    public class CreateTag
    {
        /// <summary>
        ///     The new tag's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The private board id to create the tag at (not needed for public boards)
        /// </summary>
        public long BoardId { get; set; }
    }
}