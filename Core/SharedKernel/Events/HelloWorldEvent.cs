using System;

namespace Umc.VigiFlow.Core.SharedKernel.Events
{
    public class HelloWorldEvent : Event
    {
        public string HelloWorld { get; }

        public HelloWorldEvent(Guid eventId, Guid commandId, string helloWorld) : base(eventId, commandId)
        {
            HelloWorld = helloWorld;
        }
    }
}
