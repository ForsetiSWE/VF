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

        public void Store(Case newCase)
        {
            persistance.Store(newCase, newCase.Id);
        }

        public Case Get(Guid caseId)
        {
            return persistance.Get<Case>(caseId);
        }

        #endregion ICaseRepository
    }
}
