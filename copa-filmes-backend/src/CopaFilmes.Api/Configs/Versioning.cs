using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Api.Configs
{
    public class Versioning
    {
        public static void Add(IServiceCollection services)
        {
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}