using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Components.HelloWorld.Application.Command
{
    public class HelloWorldCommandHandler : ICommandHandler
    {
        public bool CanHandle(ICommand command)
        {
            return command is HelloWorldCommand;
        }
        public void Handle(ICommand command)
        {
            
        }
    }
}
