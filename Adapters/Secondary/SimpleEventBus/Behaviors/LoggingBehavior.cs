using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleEventBus.Behaviors
{
    class LoggingBehavior<TEvent> : IEventListener<TEvent> where TEvent : IEvent
    {
        #region Setup

        private readonly IEventListener<TEvent> eventListener;
        private readonly ILogger logger;

        public LoggingBehavior(IEventListener<TEvent> eventListener, ILogger logger)
        {
            this.eventListener = eventListener;
            this.logger = logger;
        }

        #endregion Setup

        #region IEventListener

        public void OnEvent(TEvent @event)
        {
            logger.Info($"Handling of {@event} in {eventListener} started");

            eventListener.OnEvent(@event);

            logger.Info($"Handling of {@event} in {eventListener} completed");
        }

        #endregion IEventListener
    }
}
