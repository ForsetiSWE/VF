using System;
using Umc.VigiFlow.Core.Components.Case.Application.Repositories;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.Case.Application.Services
{
    public class RegisterCaseService : IRegisterCaseService
    {
        #region Setup

        private readonly ICaseRepository caseRepository;
        private readonly IEventBus eventBus;

        public RegisterCaseService(ICaseRepository caseRepository, IEventBus eventBus)
        {
            this.caseRepository = caseRepository;
            this.eventBus = eventBus;
        }

        #endregion Setup

        #region IRegisterCaseService

        public void RegisterCase(Domain.Models.Case newCase)
        {
            caseRepository.Store(newCase);

            eventBus.Publish(new CaseRegisteredEvent(Guid.NewGuid(), Guid.NewGuid(), newCase.Id));
        }

        #endregion IRegisterCaseService
    }
}
