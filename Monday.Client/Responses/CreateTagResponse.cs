using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    public class CreateTagResponse
    {
        [JsonProperty("create_or_get_tag")] public Tag Tag { get; set; }
    }
}