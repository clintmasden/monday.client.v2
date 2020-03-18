using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetBoardItemsResponse
    {
        public List<Board> Boards { get; set; }

        public class Board
        {
            public List<Item> Items { get; set; }
        }
    }
}