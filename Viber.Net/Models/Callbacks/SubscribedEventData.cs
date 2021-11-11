using System.Text.Json.Serialization;
using Viber.Net.Models.Responses;

namespace Viber.Net.Models.Callbacks
{
    /// <summary>
    /// You will receive a subscribed event when unsubscribed users do the following:
    /// 1.Open conversation with the bot.
    /// 2.Tap on the 3-dots button in the top right and then on “Chat Info”.
    /// 3.Tap on “Receive messages”.
    /// </summary>
    public class SubscribedEventData : BaseViberCallbackData
    {
        /// <summary>
        /// user details object
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
