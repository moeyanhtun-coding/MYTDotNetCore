using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.MvcApp3.Database;

namespace MYTDotNetCore.MvcApp3;

public static class ModularServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        return services.AddDbContext(builder);
    }

    public static IServiceCollection AddDbContext(this IServiceCollection service, WebApplicationBuilder builder)
    {
        string connection = builder.Configuration.GetConnectionString("DbConnection")!;
        service.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connection),
            ServiceLifetime.Transient,
            ServiceLifetime.Transient);
        return service;
    }
}