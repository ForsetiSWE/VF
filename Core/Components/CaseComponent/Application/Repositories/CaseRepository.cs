using Umc.VigiFlow.Core.Ports;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        #region Setup

        private readonly IPersistance persistance;

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
