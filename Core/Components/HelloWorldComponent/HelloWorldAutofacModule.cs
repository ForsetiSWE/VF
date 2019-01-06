using Autofac;
using Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorldComponent
{
    public class HelloWorldAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            RegisterCommands(containerBuilder);

            RegisterServices(containerBuilder);
        }

        #region Private

        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<HelloWorldService>().As<IHelloWorldService>();
        }

        private static void RegisterCommands(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<HelloWorldCommandHandler>().As<ICommandHandler<HelloWorldCommand>>();
        }

        #endregion Private
    }
}
