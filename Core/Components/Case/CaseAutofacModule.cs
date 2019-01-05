using Autofac;
using Umc.VigiFlow.Core.Components.Case.Application.Commands;
using Umc.VigiFlow.Core.Components.Case.Application.Repositories;
using Umc.VigiFlow.Core.Components.Case.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.Case
{
    public class CaseAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterCommands(builder);

            RegisterServices(builder);

            RegisterRepositories(builder);
        }

        #region Private

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<CaseRepository>().As<ICaseRepository>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterCaseService>().As<IRegisterCaseService>();
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterCaseCommandHandler>().As<ICommandHandler>();
        }

        #endregion Private
    }
}
