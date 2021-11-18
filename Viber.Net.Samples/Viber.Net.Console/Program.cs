using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Viber.Net.Console.Customization;
using Viber.Net.Extensions;
using Viber.Net.Models.Requests;

namespace Viber.Net.Console
{
    class Program
    {
        private const string callbackUrl = "your_callback_url";
        private const string authToken = "your_auth_token";
        private const bool UseCustomizedServices = true;

        static async Task Main(string[] args)
        {
            _ = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddCommandLine(args)
                    .AddEnvironmentVariables().Build();

            var consoleAppHost = CreateDefaultBuilder().Build();

            using IServiceScope serviceScope = consoleAppHost.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var viberService = provider.GetRequiredService<IViberService>();

            await ExecuteRegistrationScenario(viberService);
            await ExecuteSendMessagesScenario(viberService);
        }

        static IHostBuilder CreateDefaultBuilder() => Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app =>
                {
                    app.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    app.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices(services =>
                {
                    _ = UseCustomizedServices ? services.UseViber<MyCustomClient, MyCustomViberService, MyCustomHashValidator>(conf =>
                    {
                        conf.AuthToken = authToken;
                        conf.ThrowOnNonSuccessApiResponses = true;
                    }) : services.UseViber(conf =>
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
            var sendTextMessage = await viberService.SendMessage<SendTextMessageRequest>(new SendTextMessageRequest()
            {
                Receiver = "nanda_nani_nanda",
                Sender = new Sender
                {
                    Name = "Chris Bidis"
                },
                Text = "Welcome my friend!"
            });

            var sendPictureMessage = await viberService.SendMessage<SendPictureMessageRequest>(new SendPictureMessageRequest());
        }
    }
}
