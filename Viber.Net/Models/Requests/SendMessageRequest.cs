using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Base Send Message Request Object Properties
    /// </summary>
    public abstract class AbstractSendMessageRequest : ISendMessageViberRequest
    {
        [JsonPropertyName("sender")]
        public Sender Sender { get; set; }
        [JsonPropertyName("receiver")]
        public string Receiver { get; set; }
        [JsonPropertyName("min_api_version")]
        public int MinApiVersion { get; set; } = 1;
        [JsonPropertyName("tracking_data")]
        public string TrackingData { get; set; }
        [JsonPropertyName("type")]
        public abstract MessageType Type { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ISendMessageViberRequest : IViberRequest
    {
        /// <summary>
        /// Sender Details
        /// </summary>
        Sender Sender { get; set; }
        /// <summary>
        /// Unique Viber user id
        /// </summary>
        string Receiver { get; set; }
        /// <summary>
        /// Minimal API version required by clients for this message (default 1), optional
        /// </summary>
        int MinApiVersion { get; set; }
        /// <summary>
        /// Allow the account to track messages and user’s replies. Sent tracking_data value will be passed back with user’s reply
        /// </summary>
        string TrackingData { get; set; }
        /// <summary>
        /// message type, required. Available message types: text, picture, video, file, location, contact, sticker, carousel content and url
        /// </summary>
        MessageType Type { get; }
    }

    public class Sender
    {
        /// <summary>
        /// The sender’s name to display, required. Max 28 characters
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// optional, The sender’s avatar URL
        /// </summary>
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }

    /// <summary>
    /// Available Message Type definitions
    /// </summary>
    public enum MessageType 
    {
        Text,
        Picture,
        Video,
        File,
        Location,
        Contact,
        Sticker,
        Carousel_Content,
        Url
    }
}
