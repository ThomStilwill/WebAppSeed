using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Foundation.Application.Abstractions;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class InfrastructureModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("UnitOfWork")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
            RegisterContext<ApplicationDbContext>(builder);
        }

        public void RegisterContext<TContext>(ContainerBuilder builder) where TContext : DbContext
        {
            builder.Register(componentContext =>
                {
                    var serviceProvider = componentContext.Resolve<IServiceProvider>();
                    var configuration = componentContext.Resolve<IConfiguration>();
                    var dbContextOptions = new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>());


                    var optionsBuilder = new DbContextOptionsBuilder<TContext>(dbContextOptions)
                        .UseApplicationServiceProvider(serviceProvider)
                        .UseSqlServer(configuration.GetConnectionString("Default"),
                            s => s.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30),
                                    null))
                        ;

                    return optionsBuilder.Options;
                }
                ).As<DbContextOptions<TContext>>()
                .InstancePerLifetimeScope();

            builder.Register(context => context.Resolve<DbContextOptions<TContext>>())
                .As<DbContextOptions>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
