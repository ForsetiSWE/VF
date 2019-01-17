using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    public interface IImportRepository
    {
        void Store(Guid commandId, Import import);
    }
}