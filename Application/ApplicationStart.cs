using FluentValidation;
using Foundation.Mediator.Behaviors;
using Foundation.Mediator.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationStart
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ApplicationStart).Assembly;
            var foundationAssembly = typeof(ICommand).Assembly;
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(applicationAssembly);
                configuration.RegisterServicesFromAssembly(foundationAssembly);
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(applicationAssembly);

            return services;
        }
    }
}
