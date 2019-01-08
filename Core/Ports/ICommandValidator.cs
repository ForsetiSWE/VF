using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Ports
{
    public interface ICommandValidator
    {
        void Validate<TCommand>(TCommand entity) where TCommand : ICommand;
    }
}
