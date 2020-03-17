using System.Linq;

namespace Monday.Client.Extensions
{
    internal static class StringExtensions
    {
        internal static string FirstCharacterToUpper(this string value)
        {
            switch (value)
            {
                case "":
                case null:
                {
                    return string.Empty;
                }

                default:
                {
                    return $"{value.First().ToString().ToUpper()}{value.Substring(1)}";
                }
            }
        }
    }
}