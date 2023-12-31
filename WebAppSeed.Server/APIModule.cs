﻿using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace API
{
    public class APIModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Orchestrator")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
