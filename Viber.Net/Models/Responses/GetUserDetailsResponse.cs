using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Viber.Net.Models.Responses
{
    /// <summary>
    /// Get User Details Response Object
    /// </summary>
    public class GetUserDetailsResponse : BaseViberResponse
    {
        /// <summary>
        /// Unique id of the message
        /// </summary>
        [JsonPropertyName("message_token")]
        public long MessageToken { get; set; }
        /// <summary>
        /// user details object
        /// </summary>

        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    public class User
    {
        /// <summary>
        /// Unique Viber user id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// User’s Viber name
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// URL of the user’s avatar
        /// </summary>

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
        /// <summary>
        /// User’s country code
        /// </summary>

        [JsonPropertyName("country")]
        public string Country { get; set; }
        /// <summary>
        /// The language set in the user’s Viber settings. ISO 639-1
        /// </summary>

        [JsonPropertyName("language")]
        public string Language { get; set; }
        /// <summary>
        /// The operating system type and version of the user’s primary device.
        /// </summary>

        [JsonPropertyName("primary_device_os")]
        public string PrimaryDeviceOs { get; set; }
        /// <summary>
        /// Max API version, matching the most updated user’s device
        /// Currently only 1. Additional versions will be added in the future
        /// </summary>

        [JsonPropertyName("api_version")]
        public int ApiVersion { get; set; }
        /// <summary>
        /// The Viber version installed on the user’s primary device
        /// </summary>

        [JsonPropertyName("viber_version")]
        public string ViberVersion { get; set; }
        /// <summary>
        /// Mobile country code
        /// </summary>

        [JsonPropertyName("mcc")]
        public int Mcc { get; set; }
        /// <summary>
        /// Mobile network code
        /// </summary>

        [JsonPropertyName("mnc")]
        public int Mnc { get; set; }
        /// <summary>
        /// The user’s device type
        /// </summary>

        [JsonPropertyName("device_type")]
        public string DeviceType { get; set; }
    }
}
