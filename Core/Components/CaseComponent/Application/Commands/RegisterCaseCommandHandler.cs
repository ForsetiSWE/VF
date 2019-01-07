using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class RegisterCaseCommandHandler : ICommandHandler<RegisterCaseCommand>
    {
        #region Setup
        private readonly IRegisterCaseService registerCaseService;

        public RegisterCaseCommandHandler(IRegisterCaseService registerCaseService)
        {
            this.registerCaseService = registerCaseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(RegisterCaseCommand registerCaseCommand)
        {
            var newCase = new Case
            {
                Id = registerCaseCommand.CaseId,
                Description = registerCaseCommand.Description
            };
            registerCaseService.RegisterCase(registerCaseCommand.CommandId, newCase);
        }

        #endregion ICommandHandler
    }
}
