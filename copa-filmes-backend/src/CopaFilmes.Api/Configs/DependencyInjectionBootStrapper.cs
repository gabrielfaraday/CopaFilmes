using CopaFilmes.Api.Filters;
using CopaFilmes.Domain.Apuracoes;
using CopaFilmes.Domain.Filmes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CopaFilmes.Api.Configs
{
    public class DependencyInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IApuracaoService, ApuracaoService>();

            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
        }
    }
}
