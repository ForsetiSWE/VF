using System;
using Umc.VigiFlow.Adapters.Secondary.CommandBus;
using Umc.VigiFlow.Core.Components.Case.Application.Commands;
using Umc.VigiFlow.Core.Components.Case.Domain.Models;

namespace Umc.VigiFlow.Adapters.Primary.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandBus = new CommandBus(new HardCodedCommandHandlerFactory());

            switch (args[0].ToLower())
            {
                case "registercase":
                    commandBus.Send(new RegisterCaseCommand(new Case()));
                    break;

                    default:
                        Console.WriteLine($"Unknown command: {args[0]}");
                        break;
            }
        }
    }
}
