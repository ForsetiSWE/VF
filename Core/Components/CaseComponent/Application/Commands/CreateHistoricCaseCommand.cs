using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class CreateHistoricCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly int Revision;

        public CreateHistoricCaseCommand(Guid commandId, Guid caseId, int revision, Guid? originFromCommandId = null) : base(commandId, originFromCommandId)
        {
            CaseId = caseId;
            Revision = revision;
        }

        #endregion Setup
    }
}
