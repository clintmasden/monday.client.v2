using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    internal class GetBoardTagsResponse
    {
        public List<Board> Boards { get; set; }

        public class Board
        {
            public List<Tag> Tags { get; set; }
        }
    }
}