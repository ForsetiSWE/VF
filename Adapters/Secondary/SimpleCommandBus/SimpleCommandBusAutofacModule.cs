using Autofac;
using Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus.Behaviors;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus
{
    public class SimpleCommandBusAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();

            // Register behavior decorators for commandbus
            containerBuilder.RegisterGenericDecorator(
                typeof(LoggingBehavior<>),
                typeof(ICommandHandler<>),
                fromKey: "handler",
                toKey: "loggedHandler");
            containerBuilder.RegisterGenericDecorator(
                typeof(ValidationBehavior<>),
                typeof(ICommandHandler<>),
                fromKey: "loggedHandler");
        }
    }
}
