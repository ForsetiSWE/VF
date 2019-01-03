using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class CaseRegistreredEvent : Event
    {
        public int CaseId { get; }

        public CaseRegistreredEvent(Guid eventId, Guid commandId, int caseId) : base(eventId, commandId)
        {
            CaseId = caseId;
        }
    }
}
