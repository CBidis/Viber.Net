using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Viber.Net.Contracts;
using Viber.Net.Implementations;
using Viber.Net.Models.Requests;

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
                    services.AddHttpClient<IViberHttpClient, ViberHttpClient>(c =>
                    {
                        c.BaseAddress = new Uri("https://chatapi.viber.com/");
                        c.DefaultRequestHeaders.Add("X-Viber-Auth-Token", authToken);
                    });
                    services.AddScoped<IViberService, ViberService>();
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
    }
}
