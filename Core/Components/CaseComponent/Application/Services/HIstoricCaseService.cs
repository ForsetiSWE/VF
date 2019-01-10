using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public class HistoricCaseService : IHistoricCaseService
    {
        #region Setup

        private readonly ICaseRepository caseRepository;
        private readonly IHistoricCaseRepository historicCaseRepository;

        public HistoricCaseService(ICaseRepository caseRepository, IHistoricCaseRepository historicCaseRepository)
        {
            this.caseRepository = caseRepository;
            this.historicCaseRepository = historicCaseRepository;
        }

        #endregion Setup

        #region IHistoricCaseService
        public void CreateHistoricCase(Guid commandId, Guid historicCaseId, Guid caseId, int revision)
        {
            // Get case from repo
            var @case = caseRepository.Get(caseId, revision);

            // Create HistoricCase
            var historicCase = new HistoricCase(Guid.NewGuid(), @case);

            // Persist
            historicCaseRepository.Store(commandId, historicCase);
        }

        #endregion IHistoricCaseService
    }
}
