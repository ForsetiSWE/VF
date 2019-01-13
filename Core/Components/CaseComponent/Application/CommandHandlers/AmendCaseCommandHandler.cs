using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.CommandHandlers
{
    public class AmendCaseCommandHandler : ICommandHandler<AmendCaseCommand>
    {
        #region Setup
        private readonly ICaseService caseService;

        public AmendCaseCommandHandler(ICaseService caseService)
        {
            this.caseService = caseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(AmendCaseCommand amendCaseCommand)
        {
            caseService.AmendCase(amendCaseCommand.CommandId, amendCaseCommand.CaseId, amendCaseCommand.Revision, amendCaseCommand.Description);
        }

        #endregion ICommandHandler
    }
}
