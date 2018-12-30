using System;
using System.Collections.Generic;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public abstract class EventManager<TEvent> where TEvent : Event
    {
        private readonly List<Action<TEvent>> subscribers = new List<Action<TEvent>>();

        public void Subscribe(Action<TEvent> action)
        {
            subscribers.Add(action);
        }

        public void Publish(TEvent domainEvent)
        {
            foreach (var sub in subscribers)
            {
                sub.Invoke(domainEvent);
            }
        }
    }
}