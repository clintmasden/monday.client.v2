using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    public class GetGroupsResponse
    {
        public List<Board> Boards { get; set; }

        public class Board
        {
            public List<Group> Groups { get; set; }
        }
    }
}