using System.Linq;
using Autofac;
using Autofac.Core;
using Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Repositories;
using Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent
{
    public class AuditTrailAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            RegisterCommandHandlers(containerBuilder);

            RegisterServices(containerBuilder);

            RegisterRepositories(containerBuilder);

            RegisterEventListeners(containerBuilder);
        }

        #region Private
        
        private static void RegisterRepositories(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AuditTrailRepository>().As<IAuditTrailRepository>();
        }

        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CreateAuditTrailService>().As<ICreateAuditTrailService>();
        }

        private static void RegisterCommandHandlers(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(AuditTrailAutofacModule).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(ICommandHandler<>)))
                    .Select(i => new KeyedService("ICommandHandler", i)));
        }

        private static void RegisterEventListeners(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(AuditTrailAutofacModule).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IEventListener<>)))
                    .Select(i => new KeyedService("IEventListener", i)));
        }

        #endregion Private
    }
}
