using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        #region Setup

        private readonly IPersistance persistance;

        public CaseRepository(IPersistance persistance)
        {
            this.persistance = persistance;
        }
        
        #endregion Setup

        #region ICaseRepository

        public void Store(Guid commandId, Case newCase)
        {
            persistance.Store(commandId, newCase);
        }

        public Case Get(Guid caseId, int revision)
        {
            return persistance.Get<Case>(caseId, revision);
        }

        #endregion ICaseRepository
    }
}
