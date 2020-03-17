using Monday.Client.Models;

namespace Monday.Client.Mutations
{
    /// <summary>
    ///     Create a new board mutation.
    /// </summary>
    public class CreateBoard
    {
        /// <summary>
        ///     The board's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The board's kind. (public / private / share)
        /// </summary>
        public BoardAccessTypes BoardAccessType { get; set; }
    }
}