using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    internal class CreateColumnResponse
    {
        [JsonProperty("create_column")] public Column Column { get; set; }
    }
}