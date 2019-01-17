using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public class ImportService : IImportService
    {
        #region Setup

        private readonly IImportRepository importRepository;

        public ImportService(IImportRepository importRepository)
        {
            this.importRepository = importRepository;
        }

        #endregion Setup

        #region IImportService

        public void Import(Guid commandId, Domain.Models.Import newImport)
        {
            importRepository.Store(commandId, newImport);
        }

        #endregion IImportService
    }
}
