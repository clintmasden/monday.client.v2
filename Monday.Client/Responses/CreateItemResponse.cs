using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    public class CreateItemResponse
    {
        [JsonProperty("create_item")] public Item Item { get; set; }
    }
}