namespace Monday.Client.Models
{
    /// <summary>
    ///     The board's kind. (public / private / share)
    /// </summary>
    public enum BoardAccessTypes
    {
        /// <summary>
        ///     [Default State]
        /// </summary>
        Default,

        /// <summary>
        ///     Board is public.
        /// </summary>
        Public,

        /// <summary>
        ///     Board is private.
        /// </summary>
        Private,

        /// <summary>
        ///     Board is shared.
        /// </summary>
        Share
    }
}