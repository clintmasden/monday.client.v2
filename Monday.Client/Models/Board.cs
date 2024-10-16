using System;
using System.Collections.Generic;
using Monday.Client.Extensions;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     Monday.com boards are where our users input all of their data and as such it is one of the core components of the
    ///     platform and one of the main objects with which you will need to be familiar.
    ///     The board’s structure is composed of rows(called items), groups of rows(called groups), and columns.The data of the
    ///     board is stored in the items of the board and in the updates sections of each item. Each board has one or more
    ///     owners and subscribers.
    /// </summary>
    public class Board
    {
        /// <summary>
        ///     The unique identifier of the board.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The board's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The board's description.
        /// </summary>
        public string Description { get; set; }

        [JsonProperty("board_kind")] internal string Access { get; set; }

        /// <summary>
        ///     The board's kind. (public / private / share)
        /// </summary>
        public BoardAccessTypes BoardAccessType => Enum.TryParse(Access.FirstCharacterToUpper(), out BoardAccessTypes type) ? type : BoardAccessTypes.Default;

        [JsonProperty("state")] internal string State { get; set; }

        /// <summary>
        ///     The state of the board (all / active / archived / deleted), the default is active.
        /// </summary>
        public BoardStateTypes BoardStateType => Enum.TryParse(State.FirstCharacterToUpper(), out BoardStateTypes type) ? type : BoardStateTypes.Default;

        /// <summary>
        ///     The board's folder unique identifier.
        /// </summary>
        [JsonProperty("board_folder_id")]
        public int? BoardFolderId { get; set; }

        /// <summary>
        ///     The board's visible columns.
        /// </summary>
        public List<Column> Columns { get; set; }

        /// <summary>
        ///     The board's permissions.
        /// </summary>
        public string Permissions { get; set; }
    }
}