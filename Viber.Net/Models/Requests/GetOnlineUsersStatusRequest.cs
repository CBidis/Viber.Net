using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Get Online Users Status Request Object
    /// </summary>
    public class GetOnlineUsersStatusRequest : IViberRequest
    {
        /// <summary>
        /// Unique Viber user id, 100 ids per request
        /// </summary>
        [JsonPropertyName("ids")]
        public string[] Ids { get; set; }
    }
}
