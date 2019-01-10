using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public class AmendCaseService : IAmendCaseService
    {
        #region Setup

        private readonly ICaseRepository caseRepository;
        private readonly IEventBus eventBus;

        public AmendCaseService(ICaseRepository caseRepository, IEventBus eventBus)
        {
            this.caseRepository = caseRepository;
            this.eventBus = eventBus;
        }

        #endregion Setup

        #region IAmendCaseService

        public void AmendCase(Guid commandId, Guid caseId, int revision, string description)
        {
            // Get the case from the repository
            var existingCase = caseRepository.Get(caseId, revision);

            // Change
            existingCase.ChangeDescription(description);

            // Persist
            caseRepository.Store(commandId, existingCase);

            eventBus.Publish(new CaseAmendedEvent(Guid.NewGuid(), commandId, existingCase.Id));
        }

        #endregion IAmendCaseService
    }
}
