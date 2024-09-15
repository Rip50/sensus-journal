using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SensusJournal.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services, IConfiguration configuration) =>
            services.AddServices()
                    .ConfigureAutomapper();

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        return services;
    }

    public static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddAutoMapper(assembly);

        return services;
    }
}