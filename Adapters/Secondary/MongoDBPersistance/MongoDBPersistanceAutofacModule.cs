﻿using Autofac;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance
{
    public class MongoDBPersistanceAutofacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ConnectionStringProvider>().As<IConnectionStringProvider>();
            containerBuilder.RegisterType<Persistance>().As<IPersistance>();
        }
    }
}
