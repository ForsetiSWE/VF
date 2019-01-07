using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public interface IAmendCaseService
    {
        void AmendCase(Guid commandId, Guid caseId, string description);
    }
}