using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class AmendCaseCommandHandler : ICommandHandler<AmendCaseCommand>
    {
        #region Setup
        private readonly IAmendCaseService amendCaseService;

        public AmendCaseCommandHandler(IAmendCaseService amendCaseService)
        {
            this.amendCaseService = amendCaseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(AmendCaseCommand amendCaseCommand)
        {
            amendCaseService.AmendCase(amendCaseCommand.CommandId, amendCaseCommand.CaseId, amendCaseCommand.Revision, amendCaseCommand.Description);
        }

        #endregion ICommandHandler
    }
}
