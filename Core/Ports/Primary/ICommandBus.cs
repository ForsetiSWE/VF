using System.Collections.Generic;
using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Ports.Primary
{
    public interface ICommandBus
    {
        void RegisterHandlers(IEnumerable<ICommandHandler<ICommand>> commandHandlers);
        void Send<T>(T command) where T : ICommand;
    }
}
