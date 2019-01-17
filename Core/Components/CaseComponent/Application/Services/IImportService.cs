using System;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public interface IImportService
    {
        void Import(Guid commandId, Domain.Models.Import newImport);
    }
}