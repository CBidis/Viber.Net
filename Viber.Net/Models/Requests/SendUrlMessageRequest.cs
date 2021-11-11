using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Send Url Message Request Object
    /// </summary>
    public class SendUrlMessageRequest : AbstractSendMessageRequest
    {
        public override MessageType Type => MessageType.Url;
        /// <summary>
        /// URL required. Max 2,000 characters
        /// </summary>
        [JsonPropertyName("media")]
        public string Media { get; set; }
    }
}
