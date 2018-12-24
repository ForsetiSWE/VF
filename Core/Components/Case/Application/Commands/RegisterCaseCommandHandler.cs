using Umc.VigiFlow.Core.Components.Case.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Components.Case.Application.Commands
{
    public class RegisterCaseCommandHandler : ICommandHandler<RegisterCaseCommand>
    {
        //private readonly IRegisterCaseService registerCaseService;

        public RegisterCaseCommandHandler()
        {
            //this.registerCaseService = registerCaseService;
        }
        public void Handle(RegisterCaseCommand command)
        {
            //registerCaseService.RegisterCase(command.NewCase);
        }
    }
}
