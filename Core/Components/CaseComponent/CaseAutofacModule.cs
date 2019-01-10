using System.Linq;
using Autofac;
using Autofac.Core;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent
{
    public class CaseAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            RegisterCommandHandlers(containerBuilder);

            RegisterServices(containerBuilder);

            RegisterRepositories(containerBuilder);
        }

        #region Private

        private static void RegisterRepositories(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CaseRepository>().As<ICaseRepository>();
        }

        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<RegisterCaseService>().As<IRegisterCaseService>();
            containerBuilder.RegisterType<AmendCaseService>().As<IAmendCaseService>();
            containerBuilder.RegisterType<FollowUpCaseService>().As<IFollowUpCaseService>();
        }

        private static void RegisterCommandHandlers(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(typeof(CaseAutofacModule).Assembly)
                .As(o => o.GetInterfaces()
                    .Where(i => i.IsClosedTypeOf(typeof(ICommandHandler<>)))
                    .Select(i => new KeyedService("ICommandHandler", i)));
        }

        #endregion Private
    }
}
