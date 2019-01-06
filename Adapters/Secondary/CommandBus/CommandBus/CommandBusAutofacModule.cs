using Autofac;
using Umc.VigiFlow.Core.Ports.Secondary;

namespace Umc.VigiFlow.Adapters.Secondary.CommandBus
{
    public class CommandBusAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();
        }
    }
}
