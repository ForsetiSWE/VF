using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Commands
{
    public class HelloWorldCommand : Command
    {
        public readonly string HelloWorld;

        public HelloWorldCommand(Guid commandId, string helloWorld, Guid? originFromCommandId = null) : base(commandId, originFromCommandId)
        {
            HelloWorld = helloWorld;
        }
    }
}
