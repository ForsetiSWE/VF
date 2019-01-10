using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.CommandHandlers
{
    public class RegisterCaseCommandHandler : ICommandHandler<RegisterCaseCommand>
    {
        #region Setup
        private readonly ICaseService caseService;

        public RegisterCaseCommandHandler(ICaseService caseService)
        {
            this.caseService = caseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(RegisterCaseCommand registerCaseCommand)
        {
            var newCase = new Case(registerCaseCommand.CaseId, registerCaseCommand.Description, registerCaseCommand.InitialDate);

            caseService.RegisterCase(registerCaseCommand.CommandId, newCase);
        }

        #endregion ICommandHandler
    }
}
