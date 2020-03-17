using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    internal class CreateBoardResponse
    {
        [JsonProperty("create_board")] public Board Board { get; set; }
    }
}