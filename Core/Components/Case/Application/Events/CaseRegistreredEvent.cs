using System;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.Case.Application.Events
{
    public class CaseRegistreredEvent : Event
    {
        public Domain.Models.Case RegisteredCase { get; }

        public CaseRegistreredEvent(Guid eventId, Guid commandId, Domain.Models.Case registeredCase) : base(eventId, commandId)
        {
            RegisteredCase = registeredCase;
        }
    }
}
