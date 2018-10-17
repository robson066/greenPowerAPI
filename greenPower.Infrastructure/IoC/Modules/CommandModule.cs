using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using greenPower.Infrastructure.Commands;
using greenPower.Infrastructure.Commands.Users;
using greenPower.Infrastructure.Handlers;

namespace greenPower.Infrastructure.IoC.Modules
{
     public class CommandModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // obojętnie jaki type tutaj sprawdzamy
            var assembly = typeof(CommandModule).
                GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            // to wyżej jest po to aby skanowac CAŁE assembly i automatycznie 
            // rejestrować zależności do ioc
            //builder.RegisterType<CreateUserHandler>()
            //    .As<ICommandHandler<CreateUser>>()
            //    .InstancePerLifetimeScope();
        
            builder.RegisterType<CommandDispatcher>().
                As<ICommandDispatcher>().
                InstancePerLifetimeScope();
        }
    }
}
