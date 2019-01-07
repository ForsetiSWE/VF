using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class AmendCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly string Description;

        public AmendCaseCommand(Guid commandId, Guid caseId, string description) : base(commandId)
        {
            CaseId = caseId;
            Description = description;
        }

        #endregion Setup
    }
}
