using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class DomainEvent
    {
        #region Setup

        private readonly Guid domainEventId;
        private readonly Guid commandId;

        public DomainEvent(Guid domainEventId, Guid commandId)
        {
            this.domainEventId = domainEventId;
            this.commandId = commandId;
        }

        #endregion Setup
    }
}
