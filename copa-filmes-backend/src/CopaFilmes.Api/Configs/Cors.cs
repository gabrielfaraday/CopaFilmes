using Microsoft.AspNetCore.Builder;

namespace CopaFilmes.Api.Configs
{
    public class Cors
    {
        public static void Use(IApplicationBuilder app)
        {
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
        }
    }
}