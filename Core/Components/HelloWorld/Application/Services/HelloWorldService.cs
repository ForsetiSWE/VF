using System;
using Umc.VigiFlow.Core.Ports.Secondary;
using Umc.VigiFlow.Core.SharedKernel.Events;

namespace Umc.VigiFlow.Core.Components.HelloWorld.Application.Services
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

        public void HelloWorld(string helloWorld)
        {
            eventBus.Publish(new HelloWorldEvent(Guid.NewGuid(), Guid.NewGuid(), helloWorld));
        }

        #endregion IHelloWorldService
    }
}
