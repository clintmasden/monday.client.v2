namespace Monday.Client.Models
{
    public enum ColumnTypes
    {
        /// <summary>
        ///     Number items according to their order in the group/board
        /// </summary>
        AutoNumber,

        /// <summary>
        ///     Check off items and see what's done at a glance
        /// </summary>
        Checkbox,

        /// <summary>
        ///     Choose a country
        /// </summary>
        Country,

        /// <summary>
        ///     Manage a design system using a color palette
        /// </summary>
        ColorPicker,

        /// <summary>
        ///     Add the item creator and creation date automatically
        /// </summary>
        CreationLog,

        /// <summary>
        ///     Add dates like deadlines to ensure you never drop the ball
        /// </summary>
        Date,

        /// <summary>
        ///     Create a dropdown list of options
        /// </summary>
        Dropdown,

        /// <summary>
        ///     Email team members and clients directly from your board
        /// </summary>
        Email,

        /// <summary>
        ///     Add times to manage and schedule tasks, shifts and more
        /// </summary>
        Hour,

        /// <summary>
        ///     Show a unique ID for each item
        /// </summary>
        ItemId,

        /// <summary>
        ///     Add the person that last updated the item and the date
        /// </summary>
        LastUpdated,

        /// <summary>
        ///     Simply hyperlink to any website
        /// </summary>
        Link,

        /// <summary>
        ///     Place multiple locations on a geographic map
        /// </summary>
        Location,

        /// <summary>
        ///     Add large amounts of text without changing column width
        /// </summary>
        LongText,

        /// <summary>
        ///     Add revenue, costs, time estimations and more
        /// </summary>
        Numbers,

        /// <summary>
        ///     Assign people to improve team work
        /// </summary>
        People,

        /// <summary>
        ///     Call your contacts directly from monday.com
        /// </summary>
        Phone,

        /// <summary>
        ///     Show progress by combining status columns in a battery
        /// </summary>
        Progress,

        /// <summary>
        ///     Rate or rank anything visually
        /// </summary>
        Rating,

        /// <summary>
        ///     Get an instant overview of where things stand
        /// </summary>
        Status,

        /// <summary>
        ///     Assign a full team to an item
        /// </summary>
        Team,

        /// <summary>
        ///     Add tags to categorize items across multiple boards
        /// </summary>
        Tags,

        /// <summary>
        ///     Add textual information e.g. addresses, names or keywords
        /// </summary>
        Text,

        /// <summary>
        ///     Visually see a breakdown of your team's workload by time
        /// </summary>
        Timeline,

        /// <summary>
        ///     Basic time tracking for every item
        /// </summary>
        TimeTracking,

        /// <summary>
        ///     Vote on an item e.g. pick a new feature or a favorite lunch place
        /// </summary>
        Vote,

        /// <summary>
        ///     Select the week on which each item should be completed
        /// </summary>
        Week,

        /// <summary>
        ///     Keep track of the time anywhere in the world
        /// </summary>
        WorldClock,

        /// <summary>
        ///     NA
        /// </summary>
        Integration
    }
}