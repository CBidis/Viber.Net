using System.Text.Json.Serialization;

namespace Viber.Net.Models.Responses
{
    /// <summary>
    /// Send Message Response Object
    /// </summary>
    public class SendMessageResponse : BaseViberResponse
    {
        [JsonPropertyName("message_token")]
        public long MessageToken { get; set; }
    }
}
