using Umc.VigiFlow.Core.Components.Case.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Command;

namespace Umc.VigiFlow.Core.Components.Case.Application.Commands
{
    public class RegisterCaseCommandHandler : ICommandHandler
    {
        #region Setup
        private readonly IRegisterCaseService registerCaseService;

        public RegisterCaseCommandHandler(IRegisterCaseService registerCaseService)
        {
            this.registerCaseService = registerCaseService;
        }

        #endregion Setup

        #region ICommandHandler

        public bool CanHandle(ICommand command)
        {
            return command is RegisterCaseCommand;
        }

        public void Handle(ICommand command)
        {
            var registerCaseCommand = (RegisterCaseCommand) command;
            registerCaseService.RegisterCase(registerCaseCommand.NewCase);
        }

        #endregion ICommandHandler
    }
}
