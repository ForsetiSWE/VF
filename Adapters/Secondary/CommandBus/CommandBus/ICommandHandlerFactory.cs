using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Adapters.Secondary.CommandBus
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : ICommand;
    }
}
