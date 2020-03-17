using Monday.Client.Models;

namespace Monday.Client.Extensions
{
    internal static class UserExtensions
    {
        internal static string GetVariableUserAccessType(this UserAccessTypes userAccessType)
        {
            switch (userAccessType)
            {
                case UserAccessTypes.All:
                    return "all";

                case UserAccessTypes.NonGuests:
                    return "non_guests";

                case UserAccessTypes.Guests:
                    return "guests";

                case UserAccessTypes.NonPending:
                    return "non_pending";
            }

            return null;
        }
    }
}