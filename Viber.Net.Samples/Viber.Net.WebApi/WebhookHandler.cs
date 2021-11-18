using System.Threading.Tasks;
using Viber.Net.Contracts;
using Viber.Net.Models.Callbacks;

namespace Viber.Net.WebApi
{
    /// <summary>
    /// IHookHanlder implementation
    /// </summary>
    public class WebhookHandler : IHookHandler
    {
        /// <summary>
        /// not fully implemented but you get the concept!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callBackData"></param>
        /// <returns></returns>
        public Task<object> HandleHookAsync<T>(T callBackData) where T : ICallBackData
        {
            return null;
        }
    }
}
