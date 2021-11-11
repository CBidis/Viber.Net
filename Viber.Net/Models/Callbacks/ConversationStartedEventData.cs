using System.Text.Json.Serialization;
using Viber.Net.Models.Responses;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// Conversation started event fires when a user opens a conversation 
    /// with the bot using the “message” button (found on the account’s info screen) or using a deep link.
    /// </summary>
    public class ConversationStartedEventData : BaseViberCallbackData
    {
        /// <summary>
        /// The specific type of conversation_started event, open. Additional types may be added in the future
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// Any additional parameters added to the deep link used to access the conversation passed as a string.
        /// See deep link section for additional information
        /// </summary>
        [JsonPropertyName("context")]
        public string Context { get; set; }
        /// <summary>
        /// User Details
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
        /// <summary>
        /// indicated whether a user is already subscribed, true if subscribed and false otherwise
        /// </summary>
        [JsonPropertyName("subscribed")]
        public bool Subscribed { get; set; }
    }
}
