using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Repositories
{
    public interface IAuditTrailRepository
    {
        void Store(AuditTrail<Entity> auditTrail);
    }
}