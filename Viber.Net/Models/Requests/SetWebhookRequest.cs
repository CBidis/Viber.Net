using System.Text.Json.Serialization;
using Viber.Net.Models.Callbacks;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Set Web Hook Request Object
    /// </summary>
    public class SetWebhookRequest : IViberRequest
    {
        /// <summary>
        /// Once you have your token you will be able to set your account’s webhook. This webhook will be used for receiving callbacks and user messages from Viber.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
        /// <summary>
        /// optional. Indicates the types of Viber events that the account owner would like to be notified about.
        /// Sending a set_webhook request with no event_types parameter means getting all events. 
        /// Sending a set_webhook request with empty event_types list ("event_types": []) means getting only mandatory events.
        /// </summary>
        [JsonPropertyName("event_types")]
        public ViberEvent[] EventTypes { get; set; } = null;
        /// <summary>
        /// optional. Indicates whether or not the bot should receive the user name. Default false
        /// </summary>
        [JsonPropertyName("send_name")]
        public bool SendName { get; set; }
        /// <summary>
        /// optional. Indicates whether or not the bot should receive the user photo. Default false
        /// </summary>
        [JsonPropertyName("send_photo")]
        public bool SendPhoto { get; set; }
    }
}
