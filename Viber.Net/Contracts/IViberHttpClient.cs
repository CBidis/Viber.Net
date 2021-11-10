using System.Threading;
using System.Threading.Tasks;
using Viber.Net.Models.Requests;
using Viber.Net.Models.Responses;

namespace Viber.Net.Contracts
{
    /// <summary>
    /// Contract of Viber REST API Client
    /// </summary>
    public interface IViberHttpClient
    {
        /// <summary>
        /// Executes POST HTTP Requests to Viber Rest API
        /// </summary>
        /// <typeparam name="TRequest">viber request object that implements <see cref="IViberRequest"/></typeparam>
        /// <typeparam name="TResponse">viber response object that implements <see cref="IViberResponse"/></typeparam>
        /// <param name="path">relative path of request</param>
        /// <param name="viberRequest">viber request object</param>
        /// <param name="cancellationToken">a cancellation token</param>
        /// <returns>deserialized viber response object</returns>
        Task<TResponse> Post<TRequest, TResponse>(string path, TRequest viberRequest, CancellationToken cancellationToken = default)
            where TRequest : IViberRequest where TResponse : IViberResponse;
    }
}
