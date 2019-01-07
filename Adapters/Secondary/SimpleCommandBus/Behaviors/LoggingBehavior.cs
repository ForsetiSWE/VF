using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus.Behaviors
{
    class LoggingBehavior<TCommand> : ICommandHandlerBehavior, ICommandHandler<TCommand> where TCommand : ICommand
    {
        #region Setup

        private readonly ICommandHandler<TCommand> commandHandler;
        private readonly ILogger logger;

        public LoggingBehavior(ICommandHandler<TCommand> commandHandler, ILogger logger)
        {
            this.commandHandler = commandHandler;
            this.logger = logger;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(TCommand command)
        {
            logger.Info($"Handling of {command} started");

            commandHandler.Handle(command);

            logger.Info($"Handling of {command} completed");
        }

        #endregion ICommandHandler
    }
}
