using Microsoft.EntityFrameworkCore;

namespace MYTDotNetCore.MinimalApi
{
    public static class ModularServices
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            builder.Services.AddDbContextServices(builder).AddJsonServices(builder);
            return services;
        }

        private static IServiceCollection AddJsonServices(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            builder
                .Services.AddControllersWithViews()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            return services;
        }

        private static IServiceCollection AddDbContextServices(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            builder.Services.AddDbContext<AppDbContext>(
                opt =>
                {
                    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
                },
                ServiceLifetime.Singleton,
                ServiceLifetime.Transient
            );
            return services;
        }
    }
}
