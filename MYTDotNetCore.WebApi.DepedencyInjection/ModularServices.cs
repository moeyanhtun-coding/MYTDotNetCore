using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.Shared2;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;
using MYTDotNetCore.WebApi.DepedencyInjection.Feature.Blog;

namespace MYTDotNetCore.WebApi.DepedencyInjection
{
    public static class ModularServices
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            return services.AddDbContext(builder).AddDataAccess().AddBusinessLogic();
        }

        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<BL_Blog>();

            return services;
        }

        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<DA_Blog>();

            return services;
        }

        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            string connectionString = builder.Configuration.GetConnectionString(("DbConnection")!)!;
            builder.Services.AddDbContext<AppDbContext>(
                n => n.UseSqlServer(connectionString),
                ServiceLifetime.Transient,
                ServiceLifetime.Transient
            );

            return services;
        }
    }
}
