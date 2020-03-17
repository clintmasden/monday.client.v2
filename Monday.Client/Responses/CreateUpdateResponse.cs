using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    internal class CreateUpdateResponse
    {
        [JsonProperty("create_update")] public Update Update { get; set; }
    }
}