using System;
using Umc.VigiFlow.Adapters.Secondary.CommandBus;
using Umc.VigiFlow.Adapters.Secondary.MongoDBPersistance;
using Umc.VigiFlow.Adapters.Secondary.SimpleEventBus;
using Umc.VigiFlow.Application;
using Umc.VigiFlow.Core.Components.Case.Application.Commands;
using Umc.VigiFlow.Core.Components.Case.Domain.Models;
using Umc.VigiFlow.Core.Components.HelloWorld.Application.Commands;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace ConsoleAppTo
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus();
            var application = new Application(new CommandBus(), new Persistance("mongodb://localhost:27017"), eventBus);

            switch (args[0].ToLower())
            {
                case "registercase":
                    // We want to get the id of the case registered
                    eventBus.Subscribe<CaseRegisteredEvent>(OnCaseRegistered);

                    application.Send(new RegisterCaseCommand(Guid.NewGuid(), new Case()));
                    break;

                case "helloworld":
                    // We want to get the hello back
                    eventBus.Subscribe<HelloWorldEvent>(OnHelloWorld);

                    application.Send(new HelloWorldCommand(Guid.NewGuid(), "hello there"));
                    break;

                default:
                    Console.WriteLine($"Unknown command: {args[0]}");
                    break;
            }
        }

        private static void OnCaseRegistered(IEvent @event)
        {
            var caseRegisteredEvent = (CaseRegisteredEvent) @event;
            Console.WriteLine(caseRegisteredEvent.CaseId);
        }

        private static void OnHelloWorld(IEvent @event)
        {
            var helloWorldEvent = (HelloWorldEvent)@event;
            Console.WriteLine(helloWorldEvent.HelloWorld);
        }
    }
}
