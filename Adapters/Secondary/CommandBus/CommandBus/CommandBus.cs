using System.Collections.Generic;
using System.Linq;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.CommandBus
{
    public class CommandBus : ICommandBus
    {
        #region Setup

        private IEnumerable<ICommandHandler> commandHandlers;

        #endregion Setup

        #region ICommandBus

        public void Send(ICommand command)
        {
            // Only ONE handler per command, if in need of several handlers for same command it probably is an event!
            var commandHandler = commandHandlers.Single(handler => handler.CanHandle(command));

            commandHandler.Handle(command);
        }


        public void RegisterHandlers(IEnumerable<ICommandHandler> handlers)
        {
            commandHandlers = (commandHandlers ?? new ICommandHandler[0]).Concat(handlers);
        }

        #endregion ICommandBus
    }
}
