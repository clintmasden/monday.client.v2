namespace Monday.Client.Models
{
    /// <summary>
    ///     Monday.com tags are objects that help you group items from different groups or different boards throughout your
    ///     account by a consistent keyword. Tag entities are created and presented through the “Tags” column.
    /// </summary>
    public class Tag
    {
        /// <summary>
        ///     The tag's unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The tag's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The tag's color.
        /// </summary>
        public string Color { get; set; }
    }
}