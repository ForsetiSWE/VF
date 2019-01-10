using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class FollowUpCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly int Revision;
        public readonly string Description;
        public readonly DateTime DateOfMostRecentInformation;
        public FollowUpCaseCommand(Guid commandId, Guid caseId, int revision, string description, DateTime dateOfMostRecentInformation, Guid? originFromCommandId = null) : base(commandId, originFromCommandId)
        {
            CaseId = caseId;
            Revision = revision;
            Description = description;
            DateOfMostRecentInformation = dateOfMostRecentInformation;
        }

        #endregion Setup
    }
}
