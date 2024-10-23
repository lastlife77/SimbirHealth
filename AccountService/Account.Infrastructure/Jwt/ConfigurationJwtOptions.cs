using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Infrastructure.Jwt
{
    public static class ConfigurationJwtOptions
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

            return services;
        }
    }
}
