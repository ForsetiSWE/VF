using System;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Services
{
    public interface ICreateAuditTrailService
    {
        void CreateAuditTrail(AuditTrail<Entity> auditTrail);
    }
}