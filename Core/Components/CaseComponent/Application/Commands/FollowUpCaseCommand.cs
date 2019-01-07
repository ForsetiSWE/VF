using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class FollowUpCaseCommand : Command
    {
        #region Setup

        public readonly Guid CaseId;
        public readonly string Description;
        public readonly DateTime DateOfMostRecentInformation;

        public FollowUpCaseCommand(Guid commandId, Guid caseId, string description, DateTime dateOfMostRecentInformation) : base(commandId)
        {
            CaseId = caseId;
            Description = description;
            DateOfMostRecentInformation = dateOfMostRecentInformation;
        }

        #endregion Setup
    }
}
