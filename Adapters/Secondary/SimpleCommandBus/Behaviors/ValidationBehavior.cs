using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus.Behaviors
{
    class ValidationBehavior<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        #region Setup

        private readonly ICommandHandler<TCommand> commandHandler;
        private readonly ICommandValidator validator;

        public ValidationBehavior(ICommandHandler<TCommand> commandHandler, ICommandValidator validator)
        {
            this.commandHandler = commandHandler;
            this.validator = validator;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(TCommand command)
        {
            // Validate command, should throw ArgumentException if invalid
            validator.Validate(command);

            commandHandler.Handle(command);
        }

        #endregion ICommandHandler
    }
}
