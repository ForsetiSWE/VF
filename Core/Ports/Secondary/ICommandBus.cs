using System.Collections.Generic;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Ports.Secondary
{
    public interface ICommandBus
    {
        void RegisterHandlers(IEnumerable<ICommandHandler> commandHandlers);
        void Send(ICommand command);
    }
}
