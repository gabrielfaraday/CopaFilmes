using CopaFilmes.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Api.Configs
{
    public class Controllers
    {
        public static void Add(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalExceptionHandlingFilter)));
            })
            .AddNewtonsoftJson();
        }
    }
}