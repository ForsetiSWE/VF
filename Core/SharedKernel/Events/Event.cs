using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class Event : IEvent
    {
        #region Setup

        private readonly Guid eventId;
        private readonly Guid commandId;

        public Event(Guid eventId, Guid commandId)
        {
            this.eventId = eventId;
            this.commandId = commandId;
        }

        #endregion Setup
    }
}
