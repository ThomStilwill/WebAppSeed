using System.Reflection;
using API.Instrumentation;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Module = Autofac.Module;

namespace API
{
    public class APIModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterType<LoggerIntercepter>();


            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Orchestrator"))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(LoggerIntercepter))
                .InstancePerLifetimeScope();

        }

    }
}
