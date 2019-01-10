using System;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Repositories
{
    public class AuditTrailRepository : IAuditTrailRepository
    {
        #region Setup

        private readonly IAuditTrailPersistance auditTrailPersistance;

        public AuditTrailRepository(IAuditTrailPersistance auditTrailPersistance)
        {
            this.auditTrailPersistance = auditTrailPersistance;
        }
        
        #endregion Setup

        #region IAuditTrailRepository

        public void Store(AuditTrail<BaseEntity> auditTrail)
        {
            auditTrailPersistance.Store(auditTrail);
        }

        #endregion IAuditTrailRepository
    }
}
