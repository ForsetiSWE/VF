using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class Event : IEvent
    {
        #region Setup

        public readonly Guid EventId;
        public readonly Guid CommandId;

        public Event(Guid eventId, Guid commandId)
        {
            EventId = eventId;
            CommandId = commandId;
        }

        #endregion Setup
    }
}
