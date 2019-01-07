using Autofac;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent
{
    public class CaseAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            RegisterCommands(containerBuilder);

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

        private static void RegisterCommands(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<RegisterCaseCommandHandler>().Named<ICommandHandler<RegisterCaseCommand>>("handler");
            containerBuilder.RegisterType<AmendCaseCommandHandler>().Named<ICommandHandler<AmendCaseCommand>>("handler");
            containerBuilder.RegisterType<FollowUpCaseCommandHandler>().Named<ICommandHandler<FollowUpCaseCommand>>("handler");
        }

        #endregion Private
    }
}
