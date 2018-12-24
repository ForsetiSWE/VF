using Umc.VigiFlow.Core.Components.Case.Application.Repositories;

namespace Umc.VigiFlow.Core.Components.Case.Application.Services
{
    class RegisterCaseService : IRegisterCaseService
    {
        private readonly ICaseRepository caseRepository;

        public RegisterCaseService(ICaseRepository caseRepository)
        {
            this.caseRepository = caseRepository;
        }
        public void RegisterCase(Domain.Models.Case newCase)
        {
            caseRepository.Store(newCase);
        }
    }
}
