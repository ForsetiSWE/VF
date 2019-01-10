using System;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class EntityStoredEvent : Event
    {
        #region Properties

        public Entity StoredEntity { get; }

        #endregion Properties

        #region Setup

        public EntityStoredEvent(Guid eventId, Guid commandId, Entity storedEntity) : base(eventId, commandId)
        {
            StoredEntity = storedEntity;
        }

        #endregion Setup
    }
}
