using System.Text.Json.Serialization;
using Viber.Net.Models.Callbacks;

namespace Viber.Net.Models.Responses
{
    /// <summary>
    /// Set webhook Response
    /// </summary>
    public class SetWebhookResponse : BaseViberResponse
    {
        /// <summary>
        /// List of event types you will receive a callback for. Should return the same values sent in the request
        /// </summary>
        [JsonPropertyName("event_types")]
        public ViberEvent[] EventTypes { get; set; }
    }
}
