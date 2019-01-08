using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleCommandValidator
{
    public class CommandValidator : ICommandValidator
    {
        #region ICommandValidator

        public void Validate<TCommand>(TCommand entity) where TCommand : ICommand
        {
            // Super stupid validator, always happy
        }

        #endregion ICommandValidator
    }
}
