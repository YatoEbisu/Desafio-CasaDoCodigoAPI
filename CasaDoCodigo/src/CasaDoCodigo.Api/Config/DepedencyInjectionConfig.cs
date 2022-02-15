using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Repository;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CasaDoCodigo.Config
{
    public static class DepedencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IAutorService, AutorService>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ILivroService, LivroService>();

            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IPaisService, PaisService>();

            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEstadoService, EstadoService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}