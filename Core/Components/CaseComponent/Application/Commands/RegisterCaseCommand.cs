using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class RegisterCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly string Description;
        
        public RegisterCaseCommand(Guid commandId, Guid caseId, string description) : base(commandId)
        {
            CaseId = caseId;
            Description = description;
        }

        #endregion Setup
    }
}
