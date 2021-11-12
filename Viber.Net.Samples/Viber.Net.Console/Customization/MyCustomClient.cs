using System.Net.Http;
using Viber.Net.Configuration;
using Viber.Net.Contracts;
using Viber.Net.Implementations;

namespace Viber.Net.Console.Customization
{
    /// <summary>
    /// Custom Http Client
    /// </summary>
    public class MyCustomClient : ViberHttpClient, IViberHttpClient
    {
        public MyCustomClient(HttpClient httpClient, ViberSettings settings) : base(httpClient, settings)
        {
        }
    }
}
