using System.Text.Json.Serialization;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// Viber offers message status updates for each message sent, allowing the account to be notified 
    /// when the message was delivered to the user’s device (delivered status) 
    /// and when the conversation containing the message was opened (seen status).
    /// </summary>
    public class MessageReceiptEventData : BaseViberCallbackData
    {
        /// <summary>
        /// Unique Viber user id
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
