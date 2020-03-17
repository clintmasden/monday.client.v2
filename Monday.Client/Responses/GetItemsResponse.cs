using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    internal class GetItemsResponse
    {
        public List<Item> Items { get; set; }
    }
}