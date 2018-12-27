using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Components.Case.Application.Commands
{
    public class RegisterCaseCommand : ICommand
    {
        #region Setup

        public readonly Domain.Models.Case NewCase;

        public RegisterCaseCommand(Domain.Models.Case newCase)
        {
            NewCase = newCase;
        }

        #endregion Setup
    }
}
