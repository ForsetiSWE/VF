using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorld.Application.Commands
{
    public class HelloWorldCommand : Command
    {
        public readonly string HelloWorld;

        public HelloWorldCommand(Guid commandId, string helloWorld) : base(commandId)
        {
            HelloWorld = helloWorld;
        }
    }
}
