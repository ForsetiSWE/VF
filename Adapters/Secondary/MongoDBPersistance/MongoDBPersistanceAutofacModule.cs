using Autofac;
using Umc.VigiFlow.Core.Ports.Secondary;

namespace Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance
{
    public class MongoDBPersistanceAutofacModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register(c => new Persistance(ConnectionString)).As<IPersistance>();
        }
    }
}
