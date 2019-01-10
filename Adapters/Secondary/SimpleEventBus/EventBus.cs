using System.Collections.Generic;
using System.Linq;
using Autofac;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleEventBus
{
    public class EventBus : IEventBus
    {
        #region Setup

        private readonly IComponentContext componentContext;

        public EventBus(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }
        #endregion Setup

        #region IEventBus

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventListeners = componentContext.Resolve<IEnumerable<IEventListener<TEvent>>>().ToList();

            // Let registered event listener react on event
            eventListeners.ForEach(eventListener => eventListener.OnEvent(@event));
        }
        #endregion IEventBus
    }
}
