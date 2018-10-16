using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Ports.Primary
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : ICommand;
    }
}
