using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    public interface ICaseRepository
    {
        void Store(Guid commandId, Case newCase);
        Case Get(Guid caseId, int revision);
    }
}