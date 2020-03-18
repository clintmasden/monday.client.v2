using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetBoardsResponse
    {
        public List<Board> Boards { get; set; }
    }
}