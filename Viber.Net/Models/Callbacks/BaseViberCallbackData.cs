using System;
using System.Text.Json.Serialization;
using Viber.Net.Utilities;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// Base Viber Callback properties
    /// </summary>
    public class BaseViberCallbackData : ICallBackData
    {
        /// <summary>
        /// Callback type - which event triggered the callback
        /// </summary>
        [JsonPropertyName("event")]
        public ViberEvent Event { get; set; }
        /// <summary>
        /// Time of the event that triggered the callback Epoch time
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(UnixEpochDateTimeConverter))]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Unique ID of the message
        /// </summary>
        [JsonPropertyName("message_token")]
        public long MessageToken { get; set; }
        /// <summary>
        /// Chat Hostname identifier
        /// </summary>
        [JsonPropertyName("chat_hostname")]
        public string ChatName { get; set; }
    }

    /// <summary>
    /// contract of base callback data.
    /// </summary>
    public interface ICallBackData
    {
        ViberEvent Event { get; set; }
        DateTime Timestamp { get; set; }
        long MessageToken { get; set; }
        string ChatName { get; set; }
    }

    /// <summary>
    /// Viber Callbacks Events Type
    /// </summary>
    public enum ViberEvent
    {
        Delivered,
        Seen,
        Failed,
        Subscribed,
        Unsubscribed,
        Conversation_Started,
        Webhook,
        Client_Status,
        Action,
        Message
    }
}
