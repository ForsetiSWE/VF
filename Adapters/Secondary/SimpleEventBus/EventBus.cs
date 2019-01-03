using System;
using System.Collections.Generic;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleEventBus
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Action<IEvent>>> subscribers = new Dictionary<Type, List<Action<IEvent>>>();
        public void Subscribe<TEvent>(Action<IEvent> action) where TEvent : IEvent
        {
            var type = typeof(TEvent);
            if (!subscribers.ContainsKey(type))
            {
                subscribers.Add(type, new List<Action<IEvent>> { action });
            }
            else
            {
                subscribers[type].Add(action);
            }
        }

        public void Publish(Event @event)
        {
            var type = @event.GetType();
            if (subscribers.ContainsKey(type))
            {
                subscribers[type].ForEach(s => s.Invoke(@event));
            }
        }
    }
}
