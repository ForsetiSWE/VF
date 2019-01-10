using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Ports
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}