﻿using CopaFilmes.Api.Configs;
using CopaFilmes.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddHealthChecks();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalExceptionHandlingFilter)));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            DependencyInjectionBootStrapper.RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseHealthChecks("/api/status");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
