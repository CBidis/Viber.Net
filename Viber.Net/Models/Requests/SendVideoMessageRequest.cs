using System.Text.Json.Serialization;

namespace Viber.Net.Models.Requests
{
    /// <summary>
    /// Send Video Message Request Object
    /// </summary>
    public class SendVideoMessageRequest : AbstractSendMessageRequest
    {
        public override MessageType Type => MessageType.Video;
        /// <summary>
        /// URL of the video (MP4, H264)
        /// required. Max size 26 MB. Only MP4 and H264 are supported.
        /// The URL must have a resource with a .mp4 file extension as the last path segment. Example: http://www.example.com/path/video.mp4
        /// </summary> 
        [JsonPropertyName("media")]
        public string Media { get; set; }
        /// <summary>
        /// URL of a reduced size image (JPEG)
        /// optional. Max size 100 kb. Recommended: 400x400. Only JPEG format is supported
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
        /// <summary>
        /// Size of the video in bytes, required
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; set; }
        /// <summary>
        /// Video duration in seconds; will be displayed to the receiver, optional. Max 180 seconds
        /// </summary>
        [JsonPropertyName("duration")]
        public long Duration { get; set; }
    }
}
