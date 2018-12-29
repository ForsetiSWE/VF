using Umc.VigiFlow.Core.Ports.Secondary;

namespace Umc.VigiFlow.Core.Components.Case.Application.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly IPersistance persistance;

        #region Setup

        public CaseRepository(IPersistance persistance)
        {
            this.persistance = persistance;
        }
        #endregion Setup
        #region ICaseRepository

        public void Store(Domain.Models.Case newCase)
        {
            persistance.Store(new[] { newCase });
        }

        #endregion ICaseRepository
    }
}
