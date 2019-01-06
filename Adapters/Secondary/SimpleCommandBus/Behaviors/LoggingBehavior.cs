using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus.Behaviors
{
    class LoggingBehavior<TCommand> : ICommandHandlerBehavior, ICommandHandler<TCommand> where TCommand : ICommand
    {
        #region Setup

        private readonly ICommandHandler<TCommand> commandHandler;

        public LoggingBehavior(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(TCommand command)
        {
            Console.WriteLine($"Handling of {command} started");

            commandHandler.Handle(command);

            Console.WriteLine($"Handling of {command} completed");
        }

        #endregion ICommandHandler
    }
}
