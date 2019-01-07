using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public interface IFollowUpCaseService
    {
        void FollowUpCase(Guid commandId, Guid caseId, string description, DateTime dateOfMostRecentInformation);
    }
}