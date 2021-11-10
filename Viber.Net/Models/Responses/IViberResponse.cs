using System.Text.Json.Serialization;

namespace Viber.Net.Models.Responses
{
    /// <summary>
    /// Contract definition of Viber API Response objects
    /// </summary>
    public interface IViberResponse
    {
        /// <summary>
        /// 0 for success. In case of failure – appropriate failure status number. See error codes table for additional information
        /// </summary>
        int Status { get; set; }
        /// <summary>
        /// Success: ok. Failure: invalidUrl, invalidAuthToken, badData, missingData and failure. See error codes table for additional information
        /// </summary>
        string StatusMessage { get; set; }
    }

    /// <summary>
    /// Implements base properties of all Viber Rest API Responses
    /// </summary>
    public class BaseViberResponse : IViberResponse
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("status_message")]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Checks whether the call was successful by checking the status code value
        /// </summary>
        public bool IsSuccess => Status == 0;
    }
}
