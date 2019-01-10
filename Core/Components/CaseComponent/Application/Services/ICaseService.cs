using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public interface ICaseService
    {
        void RegisterCase(Guid commandId, Domain.Models.Case newCase);

        void AmendCase(Guid commandId, Guid caseId, int revision, string description);

        void FollowUpCase(Guid commandId, Guid caseId, int revision, string description, DateTime dateOfMostRecentInformation);
    }
}