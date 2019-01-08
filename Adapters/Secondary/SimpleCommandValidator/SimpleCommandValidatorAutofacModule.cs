using Autofac;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandValidator
{
    public class SimpleCommandValidatorAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CommandValidator>().As<ICommandValidator>();
        }
    }
}
