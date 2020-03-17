using System;
using Newtonsoft.Json;

namespace Monday.Client.Models
{
    /// <summary>
    ///     Every user in monday.com is a part of an account (i.e an organization) and could be a member or a guest in that
    ///     account.
    /// </summary>
    public class User
    {
        /// <summary>
        ///     The user's unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     The user's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The user's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     The user's profile url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     The user's photo in the original size.
        /// </summary>
        [JsonProperty("photo_original")]
        public string Photo { get; set; }

        /// <summary>
        ///     The user's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     The user's birthday.
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///     The user's country code.
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        ///     The user's location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        ///     The user's timezone identifier.
        /// </summary>
        [JsonProperty("time_zone_identifier")]
        public string TimeZoneIdentifier { get; set; }

        /// <summary>
        ///     The user's phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     The user's mobile phone number.
        /// </summary>
        [JsonProperty("mobile_phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        ///     Is the user a guest.
        /// </summary>
        [JsonProperty("is_guest")]
        public bool? IsGuest { get; set; }

        /// <summary>
        ///     Is the user a pending user.
        /// </summary>
        [JsonProperty("is_pending")]
        public bool? IsPending { get; set; }

        /// <summary>
        ///     Is the user enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? IsEnabled { get; set; }

        /// <summary>
        ///     The user's creation date.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}