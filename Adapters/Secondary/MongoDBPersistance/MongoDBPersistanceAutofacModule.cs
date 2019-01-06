using Autofac;
using Umc.VigiFlow.Core.Ports.Secondary;

namespace Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance
{
    public class MongoDBPersistanceAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Persistance("mongodb://localhost:27017")).As<IPersistance>();
        }
    }
}
