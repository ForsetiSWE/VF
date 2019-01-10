using Autofac;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Secondary.MongoDBAuditTrailPersistance
{
    public class MongoDBAuditTrailPersistanceAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>();
            containerBuilder.RegisterType<AuditTrailPersistance>().As<IAuditTrailPersistance>();
        }
    }
}
