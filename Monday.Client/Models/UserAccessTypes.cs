namespace Monday.Client.Models
{
    /// <summary>
    ///     The kind to search users by (all / non_guests / guests / non_pending).
    /// </summary>
    public enum UserAccessTypes
    {
        /// <summary>
        ///     All Users.
        /// </summary>
        All,

        /// <summary>
        ///     Non-guest Users.
        /// </summary>
        NonGuests,

        /// <summary>
        ///     Guest Users.
        /// </summary>
        Guests,

        /// <summary>
        ///     Non-Pending Users.
        /// </summary>
        NonPending
    }
}