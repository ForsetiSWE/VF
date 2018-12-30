using System;
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
            var handlers = commandHandlers.Where(commandHandler => commandHandler.CanHandle(command)).ToList();
            if (handlers.Count < 1)
            {
                throw new Exception("no handler registered");
            }

            handlers.ToList().ForEach(commandHandler => commandHandler.Handle(command));
        }


        public void RegisterHandlers(IEnumerable<ICommandHandler> handlers)
        {
            commandHandlers = (commandHandlers ?? new ICommandHandler[0]).Concat(handlers);
        }

        #endregion ICommandBus
    }
}
