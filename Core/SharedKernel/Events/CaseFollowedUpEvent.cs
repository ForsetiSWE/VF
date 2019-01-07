using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class CaseFollowedUpEvent : Event
    {
        public Guid CaseId { get; }

        public CaseFollowedUpEvent(Guid eventId, Guid commandId, Guid caseId) : base(eventId, commandId)
        {
            CaseId = caseId;
        }
    }
}
