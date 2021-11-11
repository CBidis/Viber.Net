using System.Text.Json;
using Viber.Net.Exceptions;
using Viber.Net.Middlewares;
using Viber.Net.Models.Responses;

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
        /// <summary>
        /// use this in conjuction with <see cref="ViberWebhookMiddleware"/>
        /// is required in order to use the above middleware.
        /// use '/' before the start of your relative path
        /// </summary>
        public string WebhookRelativePath { get; set; }
        /// <summary>
        /// Customized Serializer options, default value is null.
        /// </summary>
        public JsonSerializerOptions JsonSerializerOptions { get; set; } = null;
        /// <summary>
        /// if set to true, api responses will be validated on service layer 
        /// and they will be produce a <see cref="FailedApiResponseException"/>.
        /// default value is false, you can check on your layer the status of the response
        /// from <see cref="IViberResponse.IsSuccess"/> method.
        /// </summary>
        public bool ThrowOnNonSuccessApiResponses { get; set; } = false;
        /// <summary>
        /// if set to true, the <see cref="ViberWebhookMiddleware"/> will produce
        /// a <see cref="InvalidViberHashException"/>.
        /// default value is true.
        /// In case of false proccessing continues.
        /// </summary>
        public bool ThrowOnInvalidComputedHash { get; set; } = true;
    }
}
