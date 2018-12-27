using Umc.VigiFlow.Core.Components.Case.Application.Repositories;

namespace Umc.VigiFlow.Core.Components.Case.Application.Services
{
    public class RegisterCaseService : IRegisterCaseService
    {
        #region Setup

        private readonly ICaseRepository caseRepository;

        public RegisterCaseService(ICaseRepository caseRepository)
        {
            this.caseRepository = caseRepository;
        }

        #endregion Setup

        #region IRegisterCaseService

        public void RegisterCase(Domain.Models.Case newCase)
        {
            caseRepository.Store(newCase);
        }

        #endregion IRegisterCaseService
    }
}
