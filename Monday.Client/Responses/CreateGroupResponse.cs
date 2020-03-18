using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    public class CreateGroupResponse
    {
        [JsonProperty("create_group")] public Group Group { get; set; }
    }
}