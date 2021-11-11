using System.Text.Json.Serialization;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// The user will have the option to unsubscribe from the PA. This will trigger an unsubscribed callback.
    /// </summary>
    public class UnSubscribedEventData : BaseViberCallbackData
    {
        /// <summary>
        /// Unique Viber user id
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
