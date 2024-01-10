using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Register
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    }
}
