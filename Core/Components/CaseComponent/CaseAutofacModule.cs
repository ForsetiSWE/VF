using System.Linq;
using Autofac;
using Autofac.Core;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.CaseComponent
{
    public class CaseAutofacModule : Module
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
            containerBuilder.RegisterType<CaseRepository>().As<ICaseRepository>();
            containerBuilder.RegisterType<HistoricCaseRepository>().As<IHistoricCaseRepository>();
            containerBuilder.RegisterType<ImportRepository>().As<IImportRepository>();
        }

        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CaseService>().As<ICaseService>();
            containerBuilder.RegisterType<HistoricCaseService>().As<IHistoricCaseService>();
            containerBuilder.RegisterType<ImportService>().As<IImportService>();
        }

        private static void RegisterCommandHandlers(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(CaseAutofacModule).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(ICommandHandler<>)))
                    .Select(i => new KeyedService("ICommandHandler", i)));
        }

        private static void RegisterEventListeners(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(CaseAutofacModule).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(IEventListener<>)))
                    .Select(i => new KeyedService("IEventListener", i)));
        }

        #endregion Private
    }
}
