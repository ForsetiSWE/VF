using Umc.VigiFlow.Core.SharedKernel;

namespace Umc.VigiFlow.Core.Ports.Primary
{
    public interface ICommandBus
    {
        void Execute(ICommand command);
    }
}
