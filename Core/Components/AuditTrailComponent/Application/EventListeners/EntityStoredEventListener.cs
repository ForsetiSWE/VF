using Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Events;
using Umc.VigiFlow.Core.SharedKernel.Models;

namespace Umc.VigiFlow.Core.Components.AuditTrailComponent.Application.EventListeners
{
    class EntityStoredEventListener : IEventListener<EntityStoredEvent>
    {

        #region Setup

        private readonly ICreateAuditTrailService createAuditTrailService;

        public EntityStoredEventListener(ICreateAuditTrailService createAuditTrailServices)
        {
            this.createAuditTrailService = createAuditTrailServices;
        }

        #endregion Setup

        #region IEventListener

        public void OnEvent(EntityStoredEvent @event)
        {
            // Transform event to Command
            createAuditTrailService.CreateAuditTrail(new AuditTrail<Entity>(@event.CommandId, @event.StoredEntity));
        }

        #endregion IEventListener
    }
}
