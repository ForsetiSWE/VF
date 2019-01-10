using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.CommandHandlers
{
    public class FollowUpCaseCommandHandler : ICommandHandler<FollowUpCaseCommand>
    {
        #region Setup
        private readonly ICaseService caseService;

        public FollowUpCaseCommandHandler(ICaseService caseService)
        {
            this.caseService = caseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(FollowUpCaseCommand followUpCaseCommand)
        {
            caseService.FollowUpCase(followUpCaseCommand.CommandId, followUpCaseCommand.CaseId, followUpCaseCommand.Revision, followUpCaseCommand.Description, followUpCaseCommand.DateOfMostRecentInformation);
        }

        #endregion ICommandHandler
    }
}
