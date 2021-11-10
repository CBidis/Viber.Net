using System.Text.Json.Serialization;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// Shared Viber Callback properties
    /// </summary>
    public class BaseViberCallbackData
    {
        [JsonPropertyName("event")]
        public ViberEvent Event { get; set; }
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }
        [JsonPropertyName("message_token")]
        public string MessageToken { get; set; }
        
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
