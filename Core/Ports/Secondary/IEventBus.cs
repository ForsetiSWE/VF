using System;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Ports.Secondary
{
    public interface IEventBus
    {
        void Subscribe<T, TArgs>(Action<TArgs> action) where T : EventManager<TArgs>, new()
            where TArgs : DomainEvent;

        void Publish<T, TArgs>(TArgs args) where T : EventManager<TArgs>, new()
            where TArgs : DomainEvent;
    }
}