using System.Collections.Generic;
using Monday.Client.Models;

namespace Monday.Client.Responses
{
    internal class GetUsersResponse
    {
        public List<User> Users { get; set; }
    }
}