using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Viber.Net.Configuration;
using Viber.Net.Contracts;
using Viber.Net.Implementations;

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
