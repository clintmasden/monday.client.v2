using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    internal class GetBoardsResponse
    {
        public List<Board> Boards { get; set; }
    }
}