using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SensusJournal.Application.Interfaces.Data;
using SensusJournal.Infra.Data;

namespace SensusJournal.Infra.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddServices()
            .AddDatabase(configuration)
            .AddAuthenticationInternal(configuration)
            .AddAuthorizationInternal();

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("SensusJournalDbContext");
        if (!string.IsNullOrEmpty(connectionString))
        {
            services.AddDbContext<ISensusJournalDbContext, SensusJournalDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
        else
        {
            services.AddDbContext<ISensusJournalDbContext, SensusJournalDbContext>(options =>
                options.UseInMemoryDatabase("SensusJournal"));
        }
        
        return services;
    }

    public static IServiceCollection AddAuthenticationInternal(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
    {
        return services;
    }

}
