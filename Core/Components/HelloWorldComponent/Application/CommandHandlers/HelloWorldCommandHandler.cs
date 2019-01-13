using Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorldComponent.Application.CommandHandlers
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
