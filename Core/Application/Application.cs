using System.Linq;
using Umc.VigiFlow.Application.Extensions;
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

            // Register CommandHandlers
            RegisterCommandHandlers(commandBus, container);
        }

        private static void RegisterAdapters(ICommandBus commandBus, IPersistance persistance, UnityContainer container)
        {
            container.RegisterInstance(commandBus);
            container.RegisterInstance(persistance);
        }

        private static void RegisterInternals(UnityContainer container)
        {
            var coreTypes = AllClasses.FromLoadedAssemblies().Where(a => a.FullName?.StartsWith("Umc.VigiFlow.Core") ?? false).ToList();

            container.RegisterTypes(
                coreTypes,
                WithMappings.FromAllInterfaces,
                WithName.TypeName);

            //container.RegisterAllTypesForOpenGeneric(typeof(ICommandHandler<>), coreTypes);
        }

        private static void RegisterCommandHandlers(ICommandBus commandBus, UnityContainer container)
        {
            var commandHandlers = container.ResolveAll<ICommandHandler<ICommand>>();
            commandBus.RegisterHandlers(commandHandlers);
        }

        #endregion Private
    }
}
