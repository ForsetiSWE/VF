using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    class ImportRepository : IImportRepository
    {
        #region Setup

        private readonly IPersistance persistance;

        public ImportRepository(IPersistance persistance)
        {
            this.persistance = persistance;
        }

        #endregion Setup

        #region IImportRepository

        public void Store(Guid commandId, Import import)
        {
            persistance.Store(commandId, import);
        }

        #endregion IImportRepository
    }
}
