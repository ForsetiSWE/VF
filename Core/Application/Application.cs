using System.Linq;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Commands;
using Unity;
using Unity.RegistrationByConvention;

namespace Umc.VigiFlow.Application
{
    public class Application
    {
        #region Setup

        private readonly ICommandBus commandBus;

        public Application(ICommandBus commandBus, IPersistance persistance, IEventBus eventBus)
        {
            this.commandBus = commandBus;
            SetupDI(commandBus, persistance, eventBus);
        }

        #endregion Setup

        public void Send(ICommand command)
        {
            commandBus.Send(command);
        }

        #region Private

        private static void SetupDI(ICommandBus commandBus, IPersistance persistance, IEventBus eventBus)
        {
            var container = new UnityContainer();

            // Register Adapters provided to application
            RegisterAdapters(container, commandBus, persistance, eventBus);

            // Register internal interfaces
            RegisterInternals(container);

            // Register CommandHandlers in command bus
            RegisterCommandHandlers(commandBus, container);
        }

        private static void RegisterAdapters(UnityContainer container, ICommandBus commandBus, IPersistance persistance, IEventBus eventBus)
        {
            container.RegisterInstance(commandBus);
            container.RegisterInstance(persistance);
            container.RegisterInstance(eventBus);
        }

        private static void RegisterInternals(UnityContainer container)
        {
            var internalTypes = AllClasses.FromLoadedAssemblies().Where(a =>
            {
                return (a.FullName?.StartsWith("Umc.VigiFlow.Core") ?? false) && a.GetInterfaces().All(i => i.Name != "ICommandHandler" && i.Name != "ICommand");
            }).ToList();

            container.RegisterTypes(
                internalTypes,
                WithMappings.FromAllInterfaces,
                WithName.Default);
        }

        private static void RegisterCommandHandlers(ICommandBus commandBus, UnityContainer container)
        {
            var commandHandlerTypes = AllClasses.FromLoadedAssemblies().Where(a =>
            {
                return (a.FullName?.StartsWith("Umc.VigiFlow.Core") ?? false) && a.GetInterfaces().Any(i => i.Name == "ICommandHandler" || i.Name == "ICommand");
            }).ToList();

            container.RegisterTypes(
                commandHandlerTypes,
                WithMappings.FromAllInterfaces,
                WithName.TypeName);

            var commandHandlers = container.ResolveAll<ICommandHandler>();
            commandBus.RegisterHandlers(commandHandlers);
        }

        #endregion Private
    }
}
