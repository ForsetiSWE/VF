using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Ports.Secondary
{
    public interface ICommandBus
    {
        void Send(ICommand command);
    }
}
