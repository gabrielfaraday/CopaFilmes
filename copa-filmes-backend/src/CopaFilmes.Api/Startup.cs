using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configs.DependencyInjections.RegisterServices(services);
            Configs.Versioning.Add(services);
            Configs.Swagger.Add(services);
            services.AddCors();
            Configs.Controllers.Add(services);
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            Configs.Swagger.Use(app, provider);
            Configs.HealthChecks.Use(app);
            app.UseRouting();
            Configs.Cors.Use(app);
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
