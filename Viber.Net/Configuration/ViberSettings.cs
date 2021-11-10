namespace Viber.Net.Configuration
{
    /// <summary>
    /// Viber Configuration object
    /// </summary>
    public class ViberSettings
    {
        /// <summary>
        /// Viber API base url, has a defailt value of <see href="https://chatapi.viber.com/"/>
        /// use official documentation <see href="https://developers.viber.com/docs/api/rest-bot-api/"/> for more information.
        /// </summary>
        public string BaseUrl { get; set; } = "https://chatapi.viber.com/";
        /// <summary>
        /// The authentication token (also known as application key) is a unique and secret account identifier.
        /// </summary>
        public string AuthToken { get; set; }
    }
}
