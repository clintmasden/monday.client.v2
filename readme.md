# monday.client
A .NET Standard/C# implementation of Monday.com API.

| Name | Resources |
| ------ | ------ |
| APIs | https://developers.monday.com/ |
| References | https://github.com/LucyParry/MondayAPIV2_BasicExample |

#### Getting Started:
```csharp
using System;
using System.Threading.Tasks;
using Monday.Client;

namespace Monday.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MondayClient("APIKEY");

            var users = await client.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}. {user.Name}");
            }
            Console.Read();
        }
    }
}
```
