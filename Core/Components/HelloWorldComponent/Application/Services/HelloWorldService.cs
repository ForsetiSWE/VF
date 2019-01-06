using System;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        #region Setup

        private readonly IEventBus eventBus;

        public HelloWorldService(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        #endregion Setup

        #region IHelloWorldService

        public void HelloWorld(Guid commandId, string helloWorld)
        {
            eventBus.Publish(new HelloWorldEvent(Guid.NewGuid(), commandId, helloWorld));
        }

        #endregion IHelloWorldService
    }
}
