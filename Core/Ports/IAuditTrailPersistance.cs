using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IAuditTrailPersistance
    {
        void Store(AuditTrail<BaseEntity> auditTrail);
    }
}
