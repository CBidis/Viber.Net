using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Removing your webhook request object
    /// </summary>
    public class RemoveWebhookRequest
        : IViberRequest
    {
        /// <summary>
        /// At the moment there is no option to disable the 1-on-1 conversation from the bot settings,
        /// so to disable this option you’ll need to remove the webhook you set for the account.
        /// Removing the webhook is done by Posting a set_webhook request with an empty webhook string
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; } = string.Empty;
    }
}
