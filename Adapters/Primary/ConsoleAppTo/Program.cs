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
            eventBus.Subscribe<CaseRegistreredEvent>(OnCaseRegistrered);
            var application = new Application(new CommandBus(), new Persistance("mongodb://localhost:27017"), eventBus);

            switch (args[0].ToLower())
            {
                case "registercase":
                    application.Send(new RegisterCaseCommand(Guid.NewGuid(), new Case()));
                    break;

                case "helloworld":
                    application.Send(new HelloWorldCommand(Guid.NewGuid()));
                    break;

                default:
                    Console.WriteLine($"Unknown command: {args[0]}");
                    break;
            }
        }

        private static void OnCaseRegistrered(IEvent @event)
        {
            var caseRegistreredEvent = (CaseRegistreredEvent) @event;
            Console.WriteLine(caseRegistreredEvent.CaseId);
        }
    }
}
