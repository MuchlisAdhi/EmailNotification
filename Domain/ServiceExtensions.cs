using EmailNotification.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace EmailNotification.Domain;

public static class ServiceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(opt =>
                        opt.UseNpgsql(
                            configuration.GetConnectionString("DefaultConnection"),
                            b => {
                                b.MigrationsAssembly(typeof(DataContext).Assembly.FullName);
                            }
                        )
                , ServiceLifetime.Transient);

        services.AddTransient<IDataContext>(provider => provider.GetRequiredService<DataContext>());

        return services;
    }
}
