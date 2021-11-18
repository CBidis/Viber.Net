using System.Threading.Tasks;
using Viber.Net.Middlewares;
using Viber.Net.Models.Callbacks;

namespace Viber.Net.Contracts
{
    /// <summary>
    /// Web Hook Handler Contract
    /// </summary>
    public interface IHookHandler
    {
        /// <summary>
        /// Handler of viber callback data
        /// </summary>
        /// <typeparam name="T">Type parameter of callback data</typeparam>
        /// <param name="callBackData">viber callback data</param>
        /// <returns>optional data to return, if an object is received in <seealso cref="ViberWebhookMiddleware"/> 
        /// it will be serialized and forwarded to caller (Viber)
        /// </returns>
        Task<object> HandleHookAsync<T>(T callBackData) where T : ICallBackData;
    }
}
