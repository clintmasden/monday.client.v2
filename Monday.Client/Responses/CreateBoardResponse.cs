using Monday.Client.Models;
using Newtonsoft.Json;

namespace Monday.Client.Responses
{
    public class CreateBoardResponse
    {
        [JsonProperty("create_board")] public Board Board { get; set; }
    }
}