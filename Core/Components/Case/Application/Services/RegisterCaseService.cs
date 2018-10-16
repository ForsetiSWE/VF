using Umc.VigiFlow.Core.Components.Case.Application.Repositories;

namespace Umc.VigiFlow.Core.Components.Case.Application.Services
{
    class RegisterCaseService
    {
        internal void RegisterCase(Domain.Models.Case newCase)
        {
            var caseRepository = new CaseRepository();

            caseRepository.Store(newCase);
        }
    }
}
