using Monday.Client.Models;

namespace Monday.Client.Extensions
{
    internal static class BoardExtensions
    {
        internal static string GetVariableBoardAccessType(this BoardAccessTypes boardAccessType)
        {
            switch (boardAccessType)
            {
                case BoardAccessTypes.Public:
                    return "public";

                case BoardAccessTypes.Private:
                    return "private";

                case BoardAccessTypes.Share:
                    return "share";
            }

            return null;
        }

        internal static string GetVariableBoardStateType(this BoardStateTypes boardStateType)
        {
            switch (boardStateType)
            {
                case BoardStateTypes.All:
                    return "all";

                case BoardStateTypes.Active:
                    return "active";

                case BoardStateTypes.Archived:
                    return "archived";

                case BoardStateTypes.Deleted:
                    return "deleted";
            }

            return null;
        }
    }
}