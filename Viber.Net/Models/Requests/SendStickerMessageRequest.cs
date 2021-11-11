using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Send Sticker Message Request Object
    /// </summary>
    public class SendStickerMessageRequest : AbstractSendMessageRequest
    {
        public override MessageType Type => MessageType.Sticker;
        /// <summary>
        /// sticker_id Unique Viber sticker ID. For examples visit the sticker IDs page
        /// </summary>
        [JsonPropertyName("sticker_id")]
        public int StickerId { get; set; }
    }
}
