using Monday.Client.Models;

namespace Monday.Client.Extensions
{
    internal static class ColumnExtensions
    {
        internal static string GetVariableColumnType(this ColumnTypes columnType)
        {
            switch (columnType)
            {
                case ColumnTypes.AutoNumber:
                    return "auto_number";

                case ColumnTypes.ColorPicker:
                    return "color_picker";

                case ColumnTypes.CreationLog:
                    return "creation_log";

                case ColumnTypes.ItemId:
                    return "item_id";

                case ColumnTypes.LastUpdated:
                    return "last_updated";

                case ColumnTypes.LongText:
                    return "long_text";

                case ColumnTypes.TimeTracking:
                    return "time_tracking";

                case ColumnTypes.WorldClock:
                    return "world_clock";

                case ColumnTypes.Checkbox:
                case ColumnTypes.Country:
                case ColumnTypes.Date:
                case ColumnTypes.Dropdown:
                case ColumnTypes.Email:
                case ColumnTypes.Hour:
                case ColumnTypes.Link:
                case ColumnTypes.Location:
                case ColumnTypes.Numbers:
                case ColumnTypes.People:
                case ColumnTypes.Phone:
                case ColumnTypes.Progress:
                case ColumnTypes.Rating:
                case ColumnTypes.Status:
                case ColumnTypes.Team:
                case ColumnTypes.Tags:
                case ColumnTypes.Text:
                case ColumnTypes.Timeline:
                case ColumnTypes.Vote:
                case ColumnTypes.Week:
                case ColumnTypes.Integration:
                    return columnType.ToString().ToLower();
            }

            return null;
        }
    }
}