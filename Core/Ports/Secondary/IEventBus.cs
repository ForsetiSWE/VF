using System;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Ports.Secondary
{
    public interface IEventBus
    {
        void Subscribe<T, TEvent>(Action<TEvent> action) where T : EventManager<TEvent>, new()
            where TEvent : Event;

        void Publish<T, TEvent>(TEvent args) where T : EventManager<TEvent>, new()
            where TEvent : Event;
    }
}