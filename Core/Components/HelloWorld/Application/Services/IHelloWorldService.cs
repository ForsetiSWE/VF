using System;

namespace Umc.VigiFlow.Core.Components.HelloWorld.Application.Services
{
    public interface IHelloWorldService
    {
        void HelloWorld(Guid commandId, string helloWorld);
    }
}