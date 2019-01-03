using System;
using Umc.VigiFlow.Adapters.Secondary.CommandBus;
using Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance;
using Umc.VigiFlow.Adapters.Secondary.SimpleEventBus;
using Umc.VigiFlow.Core.Components.Case.Application.Commands;
using Umc.VigiFlow.Core.Components.Case.Domain.Models;
using Umc.VigiFlow.Core.Components.HelloWorld.Application.Commands;

namespace Umc.VigiFlow.Adapters.Primary.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var application = new Application.Application(new CommandBus(), new Persistance("mongodb://localhost:27017"), new EventBus());

            switch (args[0].ToLower())
            {
                case "registercase":
                    application.Send(new RegisterCaseCommand(Guid.NewGuid(), new Case()));
                    break;

                case "helloworld":
                    application.Send(new HelloWorldCommand(Guid.NewGuid(), "Hi"));
                    break;

                    default:
                        Console.WriteLine($"Unknown command: {args[0]}");
                        break;
            }
        }
    }
}
