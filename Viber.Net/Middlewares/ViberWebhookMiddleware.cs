using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Viber.Net.Contracts;
using Viber.Net.Models.Callbacks;

namespace Viber.Net.Middlewares
{
    /// <summary>
    /// Viber Hook Intereceptor Middleware
    /// </summary>
    public class ViberWebhookMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHashValidator _hashValidator;
        /// <summary>
        /// viber signature header
        /// </summary>
        protected const string ViberSingatureHeader = "X-Viber-Content-Signature";
        /// <summary>
        /// Default Json serializer options
        /// </summary>
        protected virtual JsonSerializerOptions _options => new JsonSerializerOptions
        {
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        public ViberWebhookMiddleware(RequestDelegate next, IHashValidator hashValidator)
        {
            _next = next;
            _hashValidator = hashValidator;
        }

        public virtual async Task Invoke(HttpContext context)
        {
            if (IsValidWebhookRequest(context))
            {
                var signature = context.Request.Headers[ViberSingatureHeader];
                var bodyContent = await CopyRequestBodyContentAsync(context.Request);

                var isValidRequest = _hashValidator.IsValid(signature, bodyContent);
                var deserializedBaseData = JsonSerializer.Deserialize<BaseViberCallbackData>(bodyContent, _options);

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
            => httpContext.Request.Headers.ContainsKey(ViberSingatureHeader) && httpContext.Request.Path.Value.Equals("/webhook");
    }
}
