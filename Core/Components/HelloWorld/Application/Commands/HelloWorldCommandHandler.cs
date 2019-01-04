using Umc.VigiFlow.Core.Components.HelloWorld.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.HelloWorld.Application.Commands
{
    public class HelloWorldCommandHandler : ICommandHandler
    {
        #region Setup

        private readonly IHelloWorldService helloWorldService;

        public HelloWorldCommandHandler(IHelloWorldService helloWorldService)
        {
            this.helloWorldService = helloWorldService;
        }

        #endregion Setup

        #region ICommandHandler

        public bool CanHandle(ICommand command)
        {
            return command is HelloWorldCommand;
        }

        public void Handle(ICommand command)
        {
            var helloWorldCommand = (HelloWorldCommand)command;
            helloWorldService.HelloWorld(helloWorldCommand.CommandId, helloWorldCommand.HelloWorld);
        }

        #endregion ICommandHandler
    }
}
