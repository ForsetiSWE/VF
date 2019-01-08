using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Ports
{
    public interface ICommandValidator
    {
        void Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
