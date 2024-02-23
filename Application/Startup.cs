using FluentValidation;
using Foundation.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(Startup).Assembly;

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
                configuration.RegisterServicesFromAssembly(typeof(ICommand).Assembly);
            });

            services.AddValidatorsFromAssembly(assembly);
            return services;
        }
    }
}
