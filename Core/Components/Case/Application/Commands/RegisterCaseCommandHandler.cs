using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Components.Case.Application.Commands
{
    public class RegisterCaseCommandHandler : ICommandHandler
    {
        //private readonly IRegisterCaseService registerCaseService;

        public RegisterCaseCommandHandler()
        {
            //this.registerCaseService = registerCaseService;
        }

        public bool CanHandle(ICommand command)
        {
            return command is RegisterCaseCommand;
        }

        public void Handle(ICommand command)
        {
            //registerCaseService.RegisterCase(command.NewCase);
        }
    }
}
