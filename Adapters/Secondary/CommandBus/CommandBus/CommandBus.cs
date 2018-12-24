using System;
using System.Collections.Generic;
using System.Linq;
using Umc.VigiFlow.Core.Ports.Primary;
using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Adapters.Secondary.CommandBus
{
    public class CommandBus : ICommandBus
    {
        #region Setup

        private IEnumerable<ICommandHandler<ICommand>> commandHandlers;

        #endregion Setup

        #region ICommandBus

        public void Send<T>(T command) where T : ICommand
        {
            var handlers = commandHandlers.Where(commandHandler => commandHandler is ICommandHandler<T>).ToList();
            if (handlers.Count < 1)
            {
                throw new Exception("no handler registered");
            }

            handlers.ToList().ForEach(commandHandler => commandHandler.Handle(command));
        }


        public void RegisterHandlers(IEnumerable<ICommandHandler<ICommand>> handlers)
        {
            commandHandlers = (commandHandlers ?? new ICommandHandler<ICommand>[0]).Concat(handlers);
        }

        #endregion ICommandBus
    }
}
