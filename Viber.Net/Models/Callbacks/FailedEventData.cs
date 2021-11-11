using System.Text.Json.Serialization;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// The “failed” callback will be triggered if a message has reached the client but failed any of the client validations.
    /// </summary>
    public class FailedEventData : BaseViberCallbackData
    {
        /// <summary>
        /// Unique Viber user id
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        /// <summary>
        /// A string describing the failure
        /// </summary>
        [JsonPropertyName("desc")]
        public string Description { get; set; }
    }
}
