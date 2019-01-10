using Autofac;
using Umc.VigiFlow.Adapters.Secondary.SimpleEventBus.Behaviors;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleEventBus
{
    public class SimpleEventBusAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EventBus>().As<IEventBus>().SingleInstance();

            // Register behavior decorators for commandbus
            containerBuilder.RegisterGenericDecorator(
                typeof(LoggingBehavior<>),
                typeof(IEventListener<>),
                fromKey: "IEventListener");

        }
    }
}
