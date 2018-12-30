using System;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.Case.Application.Events
{
    public class CaseRegistreredDomainEvent : DomainEvent
    {
        public Domain.Models.Case RegisteredCase { get; }

        public CaseRegistreredDomainEvent(Guid domainEventId, Guid commandId, Domain.Models.Case registeredCase) : base(domainEventId, commandId)
        {
            RegisteredCase = registeredCase;
        }
    }
}
