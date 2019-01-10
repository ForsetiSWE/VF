using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Repositories;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Services
{
    public class CaseService : ICaseService
    {
        #region Setup

        private readonly ICaseRepository caseRepository;
        private readonly IEventBus eventBus;

        public CaseService(ICaseRepository caseRepository, IEventBus eventBus)
        {
            this.caseRepository = caseRepository;
            this.eventBus = eventBus;
        }

        #endregion Setup

        #region ICaseService

        public void RegisterCase(Guid commandId, Domain.Models.Case newCase)
        {
            caseRepository.Store(commandId, newCase);

            eventBus.Publish(new CaseRegisteredEvent(Guid.NewGuid(), commandId, newCase.Id, newCase.Revision));
        }

        public void AmendCase(Guid commandId, Guid caseId, int revision, string description)
        {
            // Get the case from the repository
            var existingCase = caseRepository.Get(caseId, revision);

            // Change
            existingCase.ChangeDescription(description);

            // Persist
            caseRepository.Store(commandId, existingCase);

            eventBus.Publish(new CaseAmendedEvent(Guid.NewGuid(), commandId, existingCase.Id, existingCase.Revision));
        }

        public void FollowUpCase(Guid commandId, Guid caseId, int revision, string description, DateTime dateOfMostRecentInformation)
        {
            // Get the case from the repository
            var existingCase = caseRepository.Get(caseId, revision);

            // Change
            existingCase.ChangeDescription(description);

            // FollowUp
            existingCase.FollowUp(dateOfMostRecentInformation);

            // Persist
            caseRepository.Store(commandId, existingCase);

            eventBus.Publish(new CaseFollowedUpEvent(Guid.NewGuid(), commandId, existingCase.Id, existingCase.Revision));
        }

        #endregion ICaseService
    }
}
