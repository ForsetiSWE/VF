using System;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorld.Application.Commands
{
    public class HelloWorldCommand : Command
    {
        public HelloWorldCommand(Guid commandId) : base(commandId)
        {
        }
    }
}
