using System;
using System.Collections.Generic;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public abstract class EventManager<TDomainEvent> where TDomainEvent : DomainEvent
    {
        private readonly List<Action<TDomainEvent>> subscribers = new List<Action<TDomainEvent>>();

        public void Subscribe(Action<TDomainEvent> action)
        {
            subscribers.Add(action);
        }

        public void Publish(TDomainEvent domainEvent)
        {
            foreach (var sub in subscribers)
            {
                sub.Invoke(domainEvent);
            }
        }
    }
}