using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class CaseRegisteredEvent : Event
    {
        public Guid CaseId { get; }
        public int Revision { get; }

        public CaseRegisteredEvent(Guid eventId, Guid commandId, Guid caseId, int revision) : base(eventId, commandId)
        {
            CaseId = caseId;
            Revision = revision;
        }
    }
}
