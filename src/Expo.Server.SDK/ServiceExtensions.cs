using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Expo.Server.SDK.Interfaces;
using Expo.Server.SDK.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Expo.Server.SDK;

public static class ServiceExtensions
{
    public static IServiceCollection AddExpoPushClient(
        this IServiceCollection services,
        Action<ExpoPushClientOptions> configureOptions = null)
    {
        if (configureOptions != null)
            services.Configure(configureOptions);
        
        var options = services.BuildServiceProvider().GetService<IOptions<ExpoPushClientOptions>>()?.Value;
        if (options == null)
            throw new ArgumentNullException(nameof(options));
        
        services.AddHttpClient(ExpoPushClientOptions.DefaultHttpClientName).ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(options.ExpoBackendHost); 
            c.DefaultRequestHeaders.Accept.Clear();
            c.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }).ConfigurePrimaryHttpMessageHandler(c => new HttpClientHandler()
        {
            MaxConnectionsPerServer = options.MaxConnectionsPerServer
        });
        
        services.AddSingleton<IExpoPushClient>(s =>
        {
            var httpClientFactory = s.GetService<IHttpClientFactory>();
            var httpClientName = options.HttpClientName ?? ExpoPushClientOptions.DefaultHttpClientName;
            return new ExpoPushClient(httpClientFactory, httpClientName, options.PushSendPath, options.PushGetReceiptsPath);
        });
        
        return services;
    }
}


