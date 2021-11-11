using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Viber.Net.Models.Requests;
using Viber.Net.Extensions;
using System.Threading;
using Viber.Net.Contracts;
using System.Net.Http;
using Viber.Net.Implementations;

namespace Viber.Net.Console
{
    class Program
    {
        private const string callbackUrl = "your_callback_url";
        private const string authToken = "your_auth_token";

        static async Task Main(string[] args)
        {
            var configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddCommandLine(args)
                    .AddEnvironmentVariables().Build();

            var consoleAppHost = CreateDefaultBuilder(configurationRoot).Build();

            using IServiceScope serviceScope = consoleAppHost.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var viberService = provider.GetRequiredService<IViberService>();

            await ExecuteRegistrationScenario(viberService);
            await ExecuteSendMessagesScenario(viberService);
        }

        static IHostBuilder CreateDefaultBuilder(IConfiguration configuration) => Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    app.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices(services =>
                {
                    //services.UseViber<CustomClient, CustomService, HMACSha256Validator>(conf => 
                    //{
                    //    conf.AuthToken = authToken;
                    //    conf.ThrowOnNonSuccessApiResponses = true;
                    //});
                    services.UseViber(conf =>
                    {
                        conf.AuthToken = authToken;
                        conf.ThrowOnNonSuccessApiResponses = true;
                    });
                });


        /// <summary>
        /// Executes some basic console scenarios for registration
        /// </summary>
        /// <param name="viberService"></param>
        /// <returns></returns>
        private async static Task ExecuteRegistrationScenario(IViberService viberService)
        {
            var setWebHook = await viberService.SetWebhook(new SetWebhookRequest
            {
                Url = callbackUrl
            });

            var viberAccountInfo = await viberService.GetAccountInfo(GetAccountInfoRequest.Default);
        }

        /// <summary>
        /// Executes Messaging scenarios
        /// </summary>
        /// <param name="viberService"></param>
        /// <returns></returns>
        private async static Task ExecuteSendMessagesScenario(IViberService viberService)
        {
            var sendTextMessage = await viberService.SendMessage<SendTextMessageRequest>(new SendTextMessageRequest() { Receiver = "gtJWCVrMSPEglng/6swIpw==",
                Sender = new Sender 
                {
                    Name = "Chris Bidis"
                }, Text = "Welcome my friend!" });

            var sendPictureMessage = await viberService.SendMessage<SendPictureMessageRequest>(new SendPictureMessageRequest());
        }

        public class CustomClient : IViberHttpClient
        {
            private readonly HttpClient _client;

            public CustomClient(HttpClient client)
            {
                _client = client;
            }

            public Task<TResponse> Post<TRequest, TResponse>(string path, TRequest viberRequest, CancellationToken cancellationToken = default)
                where TRequest : IViberRequest
                where TResponse : Models.Responses.IViberResponse
            {
                throw new NotImplementedException();
            }
        }

        public class CustomService : IViberService
        {
            private readonly IViberHttpClient viberHttpClient;

            public CustomService(IViberHttpClient viberHttpClient)
            {
                this.viberHttpClient = viberHttpClient;
            }

            public Task<Models.Responses.GetAccountInfoResponse> GetAccountInfo(GetAccountInfoRequest request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task<Models.Responses.GetOnlineUsersStatusResponse> GetOnlineUsersStatus(GetOnlineUsersStatusRequest request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task<Models.Responses.GetUserDetailsResponse> GetUserDetails(GetUserDetailsRequest request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task<Models.Responses.SetWebhookResponse> RemoveWebhook(RemoveWebhookRequest request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task<Models.Responses.SendMessageResponse> SendMessage<TMessageRequest>(TMessageRequest request, CancellationToken cancellationToken = default) where TMessageRequest : ISendMessageViberRequest
            {
                throw new NotImplementedException();
            }

            public Task<Models.Responses.SetWebhookResponse> SetWebhook(SetWebhookRequest request, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
        }
    }
}
