using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Get User Details request object
    /// </summary>
    public class GetUserDetailsRequest : IViberRequest
    {
        /// <summary>
        /// Unique Viber user id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        public static GetUserDetailsRequest Create(string id) => new GetUserDetailsRequest { Id = id };
    }
}
