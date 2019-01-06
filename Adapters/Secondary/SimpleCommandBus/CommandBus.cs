using Autofac;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandBus
{
    public class CommandBus : ICommandBus
    {
        #region Setup

        private readonly IComponentContext componentContext;

        public CommandBus(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        #endregion Setup

        #region ICommandBus

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = componentContext.Resolve<ICommandHandler<TCommand>>();

            commandHandler.Handle(command);
        }

        #endregion ICommandBus
    }
}
