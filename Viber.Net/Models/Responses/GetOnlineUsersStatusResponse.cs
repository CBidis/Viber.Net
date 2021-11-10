using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Viber.Net.Models.Responses
{
    /// <summary>
    /// Get Online Users Status Response Object
    /// </summary>
    public class GetOnlineUsersStatusResponse : BaseViberResponse
    {
        /// <summary>
        /// List of online users retrieved
        /// </summary>
        [JsonPropertyName("users")]
        public List<OnlineUser> Users { get; set; }
    }

    /// <summary>
    /// Online User details object
    /// </summary>
    public class OnlineUser
    {
        /// <summary>
        /// Unique Viber user id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Online status code.
        /// 0 for online, 1 for offline, 2 for undisclosed - user set Viber to hide status,
        /// 3 for try later - internal error, 4 for unavailable - not a Viber user / unsubscribed / unregistered
        /// </summary>

        [JsonPropertyName("online_status")]
        public int OnlineStatus { get; set; }
        /// <summary>
        /// Online status message
        /// </summary>

        [JsonPropertyName("online_status_message")]
        public string OnlineStatusMessage { get; set; }

        [JsonPropertyName("last_online")]
        public long? LastOnline { get; set; }
    }

}
