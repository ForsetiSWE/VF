using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class CaseAmendedEvent : Event
    {
        public Guid CaseId { get; }

        public CaseAmendedEvent(Guid eventId, Guid commandId, Guid caseId) : base(eventId, commandId)
        {
            CaseId = caseId;
        }
    }
}
