using Autofac;
using FluentValidation;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Secondary.FluentCommandValidator
{
    public class FluentCommandValidatorAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CommandValidator>().As<ICommandValidator>();

            // Register all Validators
            containerBuilder
                .RegisterAssemblyTypes(typeof(FluentCommandValidatorAutofacModule).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();
        }
    }
}
