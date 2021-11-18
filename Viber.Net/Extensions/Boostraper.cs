using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Viber.Net.Configuration;
using Viber.Net.Contracts;
using Viber.Net.Implementations;
using Viber.Net.Middlewares;

namespace Viber.Net.Extensions
{
    /// <summary>
    /// Extension methods for Injecting Required Services 
    /// to Runtime.
    /// </summary>
    public static class Boostraper
    {
        /// <summary>
        /// Configures IServiceCollection in order to use <see cref="IViberService"/> through DI Container.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="settings">configuration object for viber</param>
        /// <returns></returns>
        public static IServiceCollection UseViber(this IServiceCollection services, Action<ViberSettings> settings)
        {
            //builds configuration settings
            var viberConfig = BuildSettings(settings);
            services.AddSingleton(viberConfig);
            services.AddSingleton<IHashValidator, HMACSha256Validator>();
            services.AddHttpClient<IViberHttpClient, ViberHttpClient>(c =>
            {
                c.BaseAddress = new Uri(viberConfig.BaseUrl);
                c.DefaultRequestHeaders.Add("X-Viber-Auth-Token", viberConfig.AuthToken);
            });
            services.AddScoped<IViberService, ViberService>();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TViberHttpClient"></typeparam>
        /// <typeparam name="THashValidator"></typeparam>
        /// <typeparam name="TViberService"></typeparam>
        /// <param name="services"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static IServiceCollection UseViber<TViberHttpClient, TViberService, THashValidator>(this IServiceCollection services, Action<ViberSettings> settings)
            where TViberHttpClient : class, IViberHttpClient where TViberService : class, IViberService where THashValidator : class, IHashValidator
        {
            //builds configuration settings
            var viberConfig = BuildSettings(settings);
            services.AddSingleton(viberConfig);
            services.AddSingleton<IHashValidator, THashValidator>();
            services.AddHttpClient<IViberHttpClient, TViberHttpClient>(c =>
            {
                c.BaseAddress = new Uri(viberConfig.BaseUrl);
                c.DefaultRequestHeaders.Add("X-Viber-Auth-Token", viberConfig.AuthToken);
            });
            services.AddScoped<IViberService, TViberService>();

            return services;
        }

        /// <summary>
        /// Registers concrete singleton implementation of <see cref="IHookHandler"/> that will be consumed
        /// through <see cref="ViberWebhookMiddleware"/> in order to process your callbacks data.
        /// Don't forget to register <see cref="ViberWebhookMiddleware"/> using 
        /// <code>app.UseMiddleware&lt;ViberWebhookMiddleware&gt;()</code>
        /// </summary>
        /// <typeparam name="THandler">type of <see cref="IHookHandler"/>></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebHookHandler<THandler>(this IServiceCollection services) 
            where THandler : class, IHookHandler => services.AddSingleton<IHookHandler, THandler>();

        private static JsonSerializerOptions GetOrSetDefaultConverters(JsonSerializerOptions jsonSerializerOptions)
        {
            if (jsonSerializerOptions == null)
            {
                return new JsonSerializerOptions
                {
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
                };
            }

            return jsonSerializerOptions;
        }

        private static ViberSettings BuildSettings(Action<ViberSettings> settings)
        {
            var viberConfig = new ViberSettings();
            settings.Invoke(viberConfig);
            viberConfig.JsonSerializerOptions = GetOrSetDefaultConverters(viberConfig.JsonSerializerOptions);

            return viberConfig;
        }
    }
}
