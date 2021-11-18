using System.Text.Json.Serialization;
using Viber.Net.Models.Requests;
using Viber.Net.Models.Responses;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// The Chat API allows the user to send messages to the PA. 
    /// Excluding file type, all message types are supported for sending from bot to user and from user to bot. 
    /// These include: text, picture, video, contact, URL and location. The following callback data describes the structure of messages sent from user to PA.
    /// </summary>
    public class MessageReceivedEventData : BaseViberCallbackData
    {
        /// <summary>
        /// this can be any any of the <see cref="ISendMessageViberRequest"/> concrete implementations
        /// </summary>
        [JsonPropertyName("message")]
        public object Message { get; set; }
        [JsonPropertyName("tracking_data")]
        public string TrackingData { get; set; }
        [JsonPropertyName("sender")]
        public User Sender { get; set; }
    }
}
