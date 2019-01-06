using Autofac;
using Umc.VigiFlow.Core.Components.Case;
using Umc.VigiFlow.Core.Components.HelloWorld;

namespace Umc.VigiFlow.Core.VigiFlowCore
{
    public class VigiFlowCoreAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CaseAutofacModule());
            builder.RegisterModule(new HelloWorldAutofacModule());
        }
    }
}
