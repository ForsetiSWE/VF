using System;

namespace Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Services
{
    public interface IHelloWorldService
    {
        void HelloWorld(Guid commandId, string helloWorld);
    }
}