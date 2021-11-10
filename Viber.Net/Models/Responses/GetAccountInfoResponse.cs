using System.Collections.Generic;
using System.Text.Json.Serialization;
using Viber.Net.Models.Callbacks;

namespace Viber.Net.Models.Responses
{
    /// <summary>
    /// Get Account Info response object
    /// </summary>
    public class GetAccountInfoResponse : BaseViberResponse
    {
        /// <summary>
        /// Unique numeric id of the account
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Account name
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// Unique URI of the Account 	
        /// </summary>

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("background")]
        public string Background { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("subcategory")]
        public string Subcategory { get; set; }
        /// <summary>
        /// Account location (coordinates). Will be used for finding accounts near me
        /// </summary>

        [JsonPropertyName("location")]
        public Location Location { get; set; }
        /// <summary>
        /// Account country, 2 letters country code - ISO ALPHA-2 Code
        /// </summary>

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("webhook")]
        public string Webhook { get; set; }

        [JsonPropertyName("event_types")]
        public ViberEvent[] EventTypes { get; set; }
        /// <summary>
        /// Number of subscribers
        /// </summary>

        [JsonPropertyName("subscribers_count")]
        public int SubscribersCount { get; set; }
        /// <summary>
        /// Members of the bot’s public chat 
        /// </summary>

        [JsonPropertyName("members")]
        public List<Member> Members { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
    }

    public class Member
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// (admin/participant)
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
