using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class CaseRegisteredEvent : Event
    {
        public Guid CaseId { get; }

        public CaseRegisteredEvent(Guid eventId, Guid commandId, Guid caseId) : base(eventId, commandId)
        {
            CaseId = caseId;
        }
    }
}
