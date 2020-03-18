using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    public class CreateColumnResponse
    {
        [JsonProperty("create_column")] public Column Column { get; set; }
    }
}