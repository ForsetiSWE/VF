using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    class HistoricCaseRepository : IHistoricCaseRepository
    {
        #region Setup

        private readonly IPersistance persistance;

        public HistoricCaseRepository(IPersistance persistance)
        {
            this.persistance = persistance;
        }

        #endregion Setup

        #region IHistoricCaseRepository

        public void Store(Guid commandId, HistoricCase historicCase)
        {
            persistance.Store(commandId, historicCase);
        }

        public Case Get(Guid caseId, int revision)
        {
            return persistance.Get<Case>(caseId, revision);
        }

        #endregion IHistoricCaseRepository
    }
}
