using Kiosco.Core.Interfaces;
using Kiosco.Infrastructure.Data;
using Kiosco.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Kiosco.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KioscoContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddDbContext<KioscoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionKioco")));
            services.AddDbContext<KioscoContextHCM>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnectionKiocoHCM")));
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "KIOSCO API", Version = "v1" });
            });

            return services;
        }

    }
}
