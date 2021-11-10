using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Send Picture Message Request Object
    /// </summary>
    public class SendPictureMessageRequest : AbstractSendMessageRequest
    {
        /// <summary>
        /// Picture Message Type
        /// </summary>
        public override MessageType Type => MessageType.Picture;
        /// <summary>
        /// The text of the message, required. Max 512 characters
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// URL of the image (JPEG, PNG, non-animated GIF)
        /// required. The URL must have a resource with a .jpeg, .png or .gif file extension as the last path segment. 
        /// Example: <see href="http://www.example.com/path/image.jpeg"/>. 
        /// Animated GIFs can be sent as URL messages or file messages. Max image size: 1MB on iOS, 3MB on Android.
        /// </summary>
        [JsonPropertyName("media")]
        public string Media { get; set; }
        /// <summary>
        /// URL of a reduced size image (JPEG, PNG, GIF)
        /// optional. Recommended: 400x400. Max size: 100kb.
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
