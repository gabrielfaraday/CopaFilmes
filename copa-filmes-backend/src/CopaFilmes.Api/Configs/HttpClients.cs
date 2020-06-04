using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace CopaFilmes.Api.Configs
{
    public class HttpClients
    {
        public static void Add(IServiceCollection services, IConfiguration configuration)
        {
            var externalApps = configuration.GetSection("ExternalCalls").AsEnumerable();

            externalApps.ToList().ForEach(_ =>
            {
                if (_.Key != "ExternalCalls")
                {
                    services.AddHttpClient(_.Key.Replace("ExternalCalls:", ""), client =>
                     {
                         client.BaseAddress = new Uri(_.Value);
                         client.DefaultRequestHeaders.Add("Accept", "application/json");
                     })
                    .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    }));
                }
            });
        }
    }
}