using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Send Text Message Request Object
    /// </summary>
    public class SendTextMessageRequest : AbstractSendMessageRequest
    {
        /// <summary>
        /// Text Message Type
        /// </summary>
        public override MessageType Type => MessageType.Text;
        /// <summary>
        /// The text of the message, required. Max length 7,000 characters
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
