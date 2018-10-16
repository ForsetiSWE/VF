using System;
using Umc.VigiFlow.Core.Ports.Primary;
using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Adapters.Secondary.CommandBus
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Send<T>(T command) where T : ICommand
        {
            var handler = _commandHandlerFactory.GetHandler<T>();
            if (handler != null)
            {
                handler.Execute(command);
            }
            else
            {
                throw new Exception("no handler registered");
            }
        }
    }
}
