using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    internal class GetBoardItemsResponse
    {
        public List<Board> Boards { get; set; }

        public class Board
        {
            public List<Item> Items { get; set; }
        }
    }
}