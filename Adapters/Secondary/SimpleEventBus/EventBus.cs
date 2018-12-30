using System;
using System.Collections.Generic;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Adapters.Secondary.SimpleEventBus
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, Func<object>> eventManagers = new Dictionary<Type, Func<object>>();

        #region IEventBus

        public void Subscribe<T, TEvent>(Action<TEvent> action) where T : EventManager<TEvent>, new() where TEvent : Event
        {
            var eventManager = GetEventManager<T, TEvent>();
            eventManager.Subscribe(action);
        }

        public void Publish<T, TEvent>(TEvent args) where T : EventManager<TEvent>, new()
            where TEvent : Event
        {
            var eventManager = GetEventManager<T, TEvent>();
            eventManager.Publish(args);
        }

        #endregion IEventBus

        #region Private

        private T GetEventManager<T, TEvent>()
            where T : EventManager<TEvent>, new()
            where TEvent : Event
        {
            if (eventManagers.ContainsKey(typeof(T)))
            {
                return eventManagers[typeof(T)]() as T;
            }

            var eventManager = new T();
            eventManagers.Add(typeof(T), () => eventManager);

            return eventManager;
        }

        #endregion Private
    }
}
