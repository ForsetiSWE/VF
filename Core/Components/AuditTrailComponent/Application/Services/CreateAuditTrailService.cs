using Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Repositories;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Services
{
    public class CreateAuditTrailService : ICreateAuditTrailService
    {
        #region Setup

        private readonly IAuditTrailRepository auditTrailRepository;

        public CreateAuditTrailService(IAuditTrailRepository auditTrailRepository)
        {
            this.auditTrailRepository = auditTrailRepository;
        }

        #endregion Setup

        #region ICreateAuditTrailService

        public void CreateAuditTrail(AuditTrail<BaseEntity> auditTrail)
        {
            auditTrailRepository.Store(auditTrail);
        }

        #endregion ICreateAuditTrailService
    }
}
