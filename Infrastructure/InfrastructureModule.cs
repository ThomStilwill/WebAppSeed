﻿using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class InfrastructureModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Data")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
