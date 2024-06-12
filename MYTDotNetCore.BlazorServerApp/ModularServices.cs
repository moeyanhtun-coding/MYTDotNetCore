using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.BlazorServerApp;

namespace MYTDotNetCore.BlazorServerApp
{
    public static class ModularServices
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            return services.AddDbContext(builder);
        }

        //public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        //{
        //    services.AddScoped<BL_Blog>().AddScoped<BL_Customer>();

        //    return services;
        //}

        //public static IServiceCollection AddDataAccess(this IServiceCollection services)
        //{
        //    services.AddScoped<DA_Blog>().AddScoped<DA_Customer>();

        //    return services;
        //}

        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            string connectionString = builder.Configuration.GetConnectionString("DbConnection"!)!;
            builder.Services.AddDbContext<AppDbContext>(
                n => n.UseSqlServer(connectionString),
                ServiceLifetime.Transient,
                ServiceLifetime.Transient
            );

            return services;
        }
    }
}
