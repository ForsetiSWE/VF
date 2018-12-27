using System.Linq;
using Umc.VigiFlow.Core.Ports.Primary;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Command;
using Unity;
using Unity.RegistrationByConvention;

namespace Umc.VigiFlow.Application
{
    public class Application
    {
        #region Setup

        private readonly ICommandBus commandBus;

        public Application(ICommandBus commandBus, IPersistance persistance)
        {
            this.commandBus = commandBus;
            SetupDI(commandBus, persistance);
        }

        #endregion Setup

        public void Send(ICommand command)
        {
            commandBus.Send(command);
        }

        #region Private

        private static void SetupDI(ICommandBus commandBus, IPersistance persistance)
        {
            var container = new UnityContainer();

            // Register Adapters provided to application
            RegisterAdapters(commandBus, persistance, container);

            // Register internal interfaces
            RegisterInternals(container);

            // Register CommandHandlers in command bus
            RegisterCommandHandlers(commandBus, container);
        }

        private static void RegisterAdapters(ICommandBus commandBus, IPersistance persistance, UnityContainer container)
        {
            container.RegisterInstance(commandBus);
            container.RegisterInstance(persistance);
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
