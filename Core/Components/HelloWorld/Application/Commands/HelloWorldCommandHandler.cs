using Umc.VigiFlow.Core.Components.HelloWorld.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorld.Application.Commands
{
    public class HelloWorldCommandHandler : ICommandHandler<HelloWorldCommand>
    {
        #region Setup

        private readonly IHelloWorldService helloWorldService;

        public HelloWorldCommandHandler(IHelloWorldService helloWorldService)
        {
            this.helloWorldService = helloWorldService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(HelloWorldCommand helloWorldCommand)
        {
            helloWorldService.HelloWorld(helloWorldCommand.CommandId, helloWorldCommand.HelloWorld);
        }

        #endregion ICommandHandler
    }
}
