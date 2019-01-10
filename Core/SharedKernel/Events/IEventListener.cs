
namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public interface IEventListener<TEvent> where TEvent : IEvent
    {
        void OnEvent(TEvent @event);
    }
}
