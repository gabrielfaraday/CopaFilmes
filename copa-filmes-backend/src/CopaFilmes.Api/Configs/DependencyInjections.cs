using CopaFilmes.Api.Filters;
using CopaFilmes.Domain.Apuracoes;
using CopaFilmes.Domain.Filmes;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Api.Configs
{
    public class DependencyInjections
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IApuracaoService, ApuracaoService>();
        }
    }
}
