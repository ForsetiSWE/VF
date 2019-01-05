using System.Collections.Generic;
using Autofac;
using Umc.VigiFlow.Core.Components.Case;
using Umc.VigiFlow.Core.Components.HelloWorld;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Application
{
    public class Application
    {
        #region Setup

        private readonly ICommandBus commandBus;

        private static IContainer Container { get; set; }

        public Application(ICommandBus commandBus, IPersistance persistance, IEventBus eventBus)
        {
            this.commandBus = commandBus;

            // Setup DI
            SetupDI(commandBus, persistance, eventBus);

            // Register command handlers in commandbus
            RegisterCommandHandlers(commandBus);
        }

        #endregion Setup

        public void Send(ICommand command)
        {
            commandBus.Send(command);
        }

        #region Private

        private static void SetupDI(ICommandBus commandBus, IPersistance persistance, IEventBus eventBus)
        {
            var builder = new ContainerBuilder();

            RegisterAdapters(commandBus, persistance, eventBus, builder);
            RegisterComponentModules(builder);

            Container = builder.Build();
        }

        private static void RegisterCommandHandlers(ICommandBus commandBus)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var commandHandlers = scope.Resolve<IEnumerable<ICommandHandler>>();
                commandBus.RegisterHandlers(commandHandlers);
            }
        }

        private static void RegisterComponentModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new CaseAutofacModule());
            builder.RegisterModule(new HelloWorldAutofacModule());
        }

        private static void RegisterAdapters(ICommandBus commandBus, IPersistance persistance, IEventBus eventBus,
            ContainerBuilder builder)
        {
            builder.RegisterInstance(commandBus).As<ICommandBus>();
            builder.RegisterInstance(persistance).As<IPersistance>();
            builder.RegisterInstance(eventBus).As<IEventBus>();
        }

        #endregion Private
    }
}
