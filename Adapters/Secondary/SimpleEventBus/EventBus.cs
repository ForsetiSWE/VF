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

        public void Subscribe<T, TArgs>(Action<TArgs> action) where T : EventManager<TArgs>, new() where TArgs : DomainEvent
        {
            var eventManager = GetEventManager<T, TArgs>();
            eventManager.Subscribe(action);
        }

        public void Publish<T, TArgs>(TArgs args) where T : EventManager<TArgs>, new()
            where TArgs : DomainEvent
        {
            var eventManager = GetEventManager<T, TArgs>();
            eventManager.Publish(args);
        }

        #endregion IEventBus

        #region Private

        private T GetEventManager<T, TArgs>()
            where T : EventManager<TArgs>, new()
            where TArgs : DomainEvent
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
