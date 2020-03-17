using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    internal class CreateGroupResponse
    {
        [JsonProperty("create_group")] public Group Group { get; set; }
    }
}