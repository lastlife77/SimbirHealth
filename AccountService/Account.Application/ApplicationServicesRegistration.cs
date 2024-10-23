using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Account.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ApplicationServicesRegistration).Assembly));

        return services;
    }
}
