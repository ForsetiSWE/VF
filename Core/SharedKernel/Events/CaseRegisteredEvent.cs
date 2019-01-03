using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class CaseRegisteredEvent : Event
    {
        public int CaseId { get; }

        public CaseRegisteredEvent(Guid eventId, Guid commandId, int caseId) : base(eventId, commandId)
        {
            CaseId = caseId;
        }
    }
}
