using System.Linq;
using Autofac;
using Autofac.Core;
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
            containerBuilder.RegisterAssemblyTypes(typeof(HelloWorldAutofacModule).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(ICommandHandler<>)))
                    .Select(i => new KeyedService("ICommandHandler", i)));
        }

        #endregion Private
    }
}
