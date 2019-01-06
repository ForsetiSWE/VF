using Autofac;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus
{
    public class CommandBusAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();
        }
    }
}
