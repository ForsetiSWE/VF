using Autofac;
using Umc.VigiFlow.Core.Components.HelloWorld.Application.Commands;
using Umc.VigiFlow.Core.Components.HelloWorld.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorld
{
    public class HelloWorldAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterCommands(builder);

            RegisterServices(builder);
        }

        #region Private

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<HelloWorldService>().As<IHelloWorldService>();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<HelloWorldCommandHandler>().As<ICommandHandler>();
        }

        #endregion Private
    }
}
