using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Ports.Primary
{
    public interface ICommandBus
    {
        void Send(ICommand command);
    }
}
