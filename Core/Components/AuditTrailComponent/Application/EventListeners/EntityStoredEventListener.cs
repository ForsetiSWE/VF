using System;
using Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Commands;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.EventListeners
{
    class EntityStoredEventListener : IEventListener<EntityStoredEvent>
    {

        #region Setup
        private readonly ICommandBus commandBus;

        public EntityStoredEventListener(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        #endregion Setup

        #region IEventListener

        public void OnEvent(EntityStoredEvent @event)
        {
            // Transform event to Command
            commandBus.Send(new CreateAuditTrailCommand(Guid.NewGuid(), @event.StoredEntity, @event.CommandId));
        }

        #endregion IEventListener
    }
}
