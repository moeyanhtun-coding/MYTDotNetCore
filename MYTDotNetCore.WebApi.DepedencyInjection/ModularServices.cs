using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.Shared2;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;

namespace MYTDotNetCore.WebApi.DepedencyInjection
{
    public static class ModularServices
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            WebApplicationBuilder builder
        )
        {
            string connectionString = builder.Configuration.GetConnectionString(
                builder.Configuration.GetConnectionString("DbConnection")!
            )!;
            builder.Services.AddScoped(n => new AdoDotNetService(connectionString));
            builder.Services.AddScoped(n => new DapperService(connectionString));
            builder.Services.AddDbContext<AppDbContext>(
                n => n.UseSqlServer(connectionString),
                ServiceLifetime.Transient,
                ServiceLifetime.Transient
            );
            return services;
        }
    }
}
