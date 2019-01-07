using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class AmendCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly int Revision;
        public readonly string Description;

        public AmendCaseCommand(Guid commandId, Guid caseId, int revision, string description) : base(commandId)
        {
            CaseId = caseId;
            Revision = revision;
            Description = description;
        }

        #endregion Setup
    }
}
