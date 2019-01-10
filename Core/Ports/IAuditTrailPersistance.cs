using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IAuditTrailPersistance
    {
        void Store(AuditTrail<Entity> auditTrail);
    }
}
