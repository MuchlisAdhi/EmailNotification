using EmailNotification.Infrastructures.Services;

namespace EmailNotification;

public static class ConfigureService
{
    public static IServiceCollection AddConfigureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddRazorPages().AddApplicationPart(typeof(ConfigureService).Assembly);

        services.AddScoped<IRazorRendererHelper, RazorRendererHelper>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IRepositoryService, RepositoryService>();
        return services;
    }
}
