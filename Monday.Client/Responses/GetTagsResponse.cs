using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    internal class GetTagsResponse
    {
        public List<Tag> Tags { get; set; }
    }
}