using System;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(Action<IEvent> action) where TEvent : IEvent;
        void Publish(Event @event);
    }
}