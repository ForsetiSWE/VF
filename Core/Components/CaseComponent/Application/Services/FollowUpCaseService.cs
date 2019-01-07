using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public class FollowUpCaseService : IFollowUpCaseService
    {
        #region Setup

        private readonly ICaseRepository caseRepository;
        private readonly IEventBus eventBus;

        public FollowUpCaseService(ICaseRepository caseRepository, IEventBus eventBus)
        {
            this.caseRepository = caseRepository;
            this.eventBus = eventBus;
        }

        #endregion Setup

        #region IFollowUpCaseService

        public void FollowUpCase(Guid commandId, Guid caseId, int revision, string description, DateTime dateOfMostRecentInformation)
        {
            // Get the case from the repository
            var existingCase = caseRepository.Get(caseId, revision);

            // Change
            existingCase.ChangeDescription(description);

            // FollowUp
            existingCase.FollowUp(dateOfMostRecentInformation);

            // Persist
            caseRepository.Store(existingCase);

            eventBus.Publish(new CaseFollowedUpEvent(Guid.NewGuid(), commandId, existingCase.Id));
        }

        #endregion IFollowUpCaseService
    }
}
