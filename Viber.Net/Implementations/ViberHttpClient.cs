using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Viber.Net.Contracts;
using Viber.Net.Models.Requests;
using Viber.Net.Models.Responses;

namespace Viber.Net.Implementations
{
    /// <summary>
    /// Concrete Implementation of <see cref="IViberHttpClient"/>
    /// </summary>
    public class ViberHttpClient : IViberHttpClient
    {
        private readonly HttpClient _httpClient;
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

        public ViberHttpClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<TResponse> Post<TRequest, TResponse>(string path, TRequest viberRequest, CancellationToken cancellationToken = default)
            where TRequest : IViberRequest
            where TResponse : IViberResponse
        {
            var serializedRequest = JsonSerializer.Serialize(viberRequest, typeof(TRequest), _options);
            var httpResponse = await _httpClient.PostAsync(path, new StringContent(serializedRequest, Encoding.UTF8), cancellationToken);
            var jsonStringResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(jsonStringResponse, _options);
        }
    }
}
