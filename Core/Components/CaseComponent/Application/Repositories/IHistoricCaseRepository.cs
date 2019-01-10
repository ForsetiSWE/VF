using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    public interface IHistoricCaseRepository
    {
        void Store(Guid commandId, HistoricCase historicCase);
    }
}