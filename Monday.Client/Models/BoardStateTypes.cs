namespace Monday.Client.Models
{
    /// <summary>
    ///     The state of the board. (all / active / archived / deleted)
    /// </summary>
    public enum BoardStateTypes
    {
        /// <summary>
        ///     [Default State]
        /// </summary>
        Default,

        /// <summary>
        ///     Board is all types.
        /// </summary>
        All,

        /// <summary>
        ///     Board is active.
        /// </summary>
        Active,

        /// <summary>
        ///     Board is archived.
        /// </summary>
        Archived,

        /// <summary>
        ///     Board is deleted.
        /// </summary>
        Deleted
    }
}