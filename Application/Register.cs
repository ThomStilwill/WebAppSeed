using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Register
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(Register).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
