using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Viber.Net.Configuration;
using Viber.Net.Contracts;
using Viber.Net.Exceptions;
using Viber.Net.Models.Callbacks;

namespace Viber.Net.Middlewares
{
    /// <summary>
    /// Viber Hook Intereceptor Middleware
    /// </summary>
    public class ViberWebhookMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ViberSettings _settings;
        private readonly IHashValidator _hashValidator;
        /// <summary>
        /// viber signature header
        /// </summary>
        protected const string ViberSingatureHeader = "X-Viber-Content-Signature";
        /// <summary>
        /// Default Json serializer options
        /// </summary>

        public ViberWebhookMiddleware(RequestDelegate next, ViberSettings settings, IHashValidator hashValidator)
        {
            _next = next;
            _hashValidator = hashValidator ?? throw new ArgumentNullException(nameof(hashValidator));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _settings.WebhookRelativePath = settings.WebhookRelativePath ?? throw new ArgumentNullException(nameof(ViberSettings.WebhookRelativePath));
        }

        public virtual async Task Invoke(HttpContext context)
        {
            if (IsValidWebhookRequest(context))
            {
                var computedSignBytes = Array.Empty<byte>();
                var signature = context.Request.Headers[ViberSingatureHeader];

                var bodyContent = await CopyRequestBodyContentAsync(context.Request);

                bool isValidRequest = _hashValidator.IsValid(signature, bodyContent, out computedSignBytes);

                if(_settings.ThrowOnInvalidComputedHash && !isValidRequest)
                {
                    throw new InvalidViberHashException(signature, computedSignBytes, bodyContent);
                }

                var deserializedBaseData = JsonSerializer.Deserialize<BaseViberCallbackData>(bodyContent, _settings.JsonSerializerOptions);
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";
                return;
            }

            await _next(context);
        }

        /// <summary>
        /// Makes A Copy Of RequestBody Raw Bytes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected virtual async Task<byte[]> CopyRequestBodyContentAsync(HttpRequest request)
        {
            if (!request.Body.CanSeek)
            {
                // We only do this if the stream isn't *already* seekable,
                // as EnableBuffering will create a new stream instance
                // each time it's called
                request.EnableBuffering();
            }

            request.Body.Position = 0;
            using (var stream = new MemoryStream())
            {
                await request.Body.CopyToAsync(stream);
                return stream.ToArray();  // returns base64 encoded string JSON result
            }
        }

        /// <summary>
        /// checking header and request path
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected virtual bool IsValidWebhookRequest(HttpContext httpContext) 
            => httpContext.Request.Headers.ContainsKey(ViberSingatureHeader) && httpContext.Request.Path.Value.Equals(_settings.WebhookRelativePath);
    }
}
