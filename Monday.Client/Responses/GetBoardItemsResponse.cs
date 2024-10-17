using System.Collections.Generic;
using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    public class GetBoardItemsResponse
    {
        public List<Board> Boards { get; set; }
        public class Board
        {
            [JsonProperty("items_page")] public ItemsPage ItemsPage { get; set; }
        }
        public class ItemsPage
        {
            public List<Item> Items { get; set; }

        }
    }
}