using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public interface IHistoricCaseService
    {
        void CreateHistoricCase(Guid commandId, Guid historicCaseId, Guid caseId, int revision);
    }
}