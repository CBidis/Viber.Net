using System.Text.Json.Serialization;
using Viber.Net.Models.Responses;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Send Location Message Request Object
    /// </summary>
    public class SendLocationMessageRequest : AbstractSendMessageRequest
    {
        public override MessageType Type => MessageType.Location;
        /// <summary>
        /// Location coordinates required. latitude (±90°) and longitude (±180°) within valid ranges
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }
}
