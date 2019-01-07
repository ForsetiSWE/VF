using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus.Behaviors
{
    class ValidationBehavior<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        #region Setup

        private readonly ICommandHandler<TCommand> commandHandler;

        public ValidationBehavior(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(TCommand command)
        {
            //TODO validation with injected adapter

            commandHandler.Handle(command);
        }

        #endregion ICommandHandler
    }
}
