# monday.client

A .NET Standard/C# implementation of the Monday.com API.

## Important Notice

This repository is currently in **limited maintenance mode**. We welcome contributions in the form of pull requests (PRs) for any breaking changes or modifications. However, please ensure that all PRs include a comprehensive sample demonstrating the proposed changes. Upon verification and confirmation of the sample, a new version will be released.

## Resources

| Name       | Resources                                       |
|------------|-------------------------------------------------|
| APIs       | [Monday.com API Documentation](https://developers.monday.com/) |
| References | [Basic Example on GitHub](https://github.com/LucyParry/MondayAPIV2_BasicExample) |

## Getting Started

```csharp
using System;
using Monday.Client;

namespace Monday.App
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var client = new MondayClient("APIKEY");

            var users = client.GetUsers().Result;

            users.ForEach(user => Console.WriteLine($"{user.Id}. {user.Name}"));
            Console.Read();
        }
    }
}
```
