using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.Case.Application.Commands
{
    public class RegisterCaseCommand : Command
    {
        #region Setup

        public readonly Domain.Models.Case NewCase;

        public RegisterCaseCommand(Guid commandId, Domain.Models.Case newCase) : base(commandId)
        {
            NewCase = newCase;
        }

        #endregion Setup
    }
}
