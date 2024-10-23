using Account.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Account.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var dsBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dsBuilder.EnableDynamicJson();
        var dbDataSource = dsBuilder.Build();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IRepository, Repository>();

        return services;
    }
}
