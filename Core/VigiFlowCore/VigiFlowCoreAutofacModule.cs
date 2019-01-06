using Autofac;
using Umc.VigiFlow.Core.Components.CaseComponent;
using Umc.VigiFlow.Core.Components.HelloWorldComponent;

namespace Umc.VigiFlow.Core.VigiFlowCore
{
    public class VigiFlowCoreAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CaseAutofacModule>();
            builder.RegisterModule<HelloWorldAutofacModule>();
        }
    }
}
