using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using CasaDoCodigo.Config;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CasaDoCodigo.Infra.Data.Repository;

namespace CasaDoCodigo
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
            services.AddDbContext<ApplicationContext>(opt => opt
                .UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
            );

            services.AddDependencyInjection();
            services.AddApiConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApiConfig(env);
        }
    }
}
