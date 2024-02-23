using System.Reflection;
using Autofac;
using Foundation.Infrastructure;
using MediatR;
using Module = Autofac.Module;

namespace Application
{
    public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(IRequestHandler<>));
        }
    }
}
