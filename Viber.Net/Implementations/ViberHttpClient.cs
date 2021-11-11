using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Viber.Net.Configuration;
using Viber.Net.Contracts;
using Viber.Net.Exceptions;
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
        private readonly ViberSettings _settings;
        private readonly JsonSerializerOptions _options;

        public ViberHttpClient(HttpClient httpClient, ViberSettings settings)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
            _options = settings.JsonSerializerOptions;
        }

        public async Task<TResponse> Post<TRequest, TResponse>(string path, TRequest viberRequest, CancellationToken cancellationToken = default)
            where TRequest : IViberRequest
            where TResponse : IViberResponse
        {
            var serializedRequest = JsonSerializer.Serialize(viberRequest, typeof(TRequest), _options);
            var httpResponse = await _httpClient.PostAsync(path, new StringContent(serializedRequest, Encoding.UTF8), cancellationToken);

            var jsonStringResponse = await httpResponse.Content.ReadAsStringAsync();
            var deserializedResponse = JsonSerializer.Deserialize<TResponse>(jsonStringResponse, _options);

            if (_settings.ThrowOnNonSuccessApiResponses && !deserializedResponse.IsSuccess)
            {
                throw new FailedApiResponseException(deserializedResponse.Status, deserializedResponse.StatusMessage);
            }

            return deserializedResponse;
        }
    }
}
