using System;
using Autofac;
using Umc.VigiFlow.Adapters.Secondary.ConsoleLogger;
using Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance;
using Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus;
using Umc.VigiFlow.Adapters.Secondary.SimpleEventBus;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Commands;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.VigiFlowCore;

namespace Umc.VigiFlow.Adapters.Primary.ConsoleApp
{
    class Program
    {
        #region Setup

        private static IContainer Container { get; set; }

        #endregion Setup

        static void Main(string[] args)
        {
            SetupDI();

            var commandBus = Container.Resolve<ICommandBus>();

            switch (args[0].ToLower())
            {
                case "registercase":
                    commandBus.Send(new RegisterCaseCommand(Guid.NewGuid(), Guid.NewGuid(), args[1], DateTime.Parse(args[2])));
                    break;

                case "amendcase":
                    commandBus.Send(new AmendCaseCommand(Guid.NewGuid(), Guid.Parse(args[1]), args[2]));
                    break;

                case "followupcase":
                    commandBus.Send(new FollowUpCaseCommand(Guid.NewGuid(), Guid.Parse(args[1]), args[2], DateTime.Parse(args[3])));
                    break;

                case "helloworld":
                    commandBus.Send(new HelloWorldCommand(Guid.NewGuid(), args[1]));
                    break;

                    default:
                        Console.WriteLine($"Unknown command: {args[0]}");
                        break;
            }
        }

        #region Private

        private static void SetupDI()
        {
            // Create ContainerBuilder
            var containerBuilder = new ContainerBuilder();

            // Setup DI for VigiFlowCore
            containerBuilder.RegisterModule(new VigiFlowCoreAutofacModule());

            // Setup DI for Secondary adapters used
            RegisterSecondaryAdapters(containerBuilder);

            // Create Container
            Container = containerBuilder.Build();
        }

        private static void RegisterSecondaryAdapters(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<SimpleCommandBusAutofacModule>();
            containerBuilder.RegisterModule<SimpleEventBusAutofacModule>();
            containerBuilder.RegisterModule(new MongoDBPersistanceAutofacModule
            {
                ConnectionString = "mongodb://localhost:27017"
            });
            containerBuilder.RegisterModule<ConsoleLoggerAutofacModule>();
        }

        #endregion Private
    }
}
