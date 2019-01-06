using Autofac;
using Umc.VigiFlow.Core.Ports.Secondary;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleEventBus
{
    public class EventBusAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EventBus>().As<IEventBus>().SingleInstance();
        }
    }
}
