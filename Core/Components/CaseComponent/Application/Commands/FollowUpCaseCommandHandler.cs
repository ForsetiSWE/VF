using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands
{
    public class FollowUpCaseCommandHandler : ICommandHandler<FollowUpCaseCommand>
    {
        #region Setup
        private readonly IFollowUpCaseService followUpCaseService;

        public FollowUpCaseCommandHandler(IFollowUpCaseService followUpCaseService)
        {
            this.followUpCaseService = followUpCaseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(FollowUpCaseCommand followUpCaseCommand)
        {
            followUpCaseService.FollowUpCase(followUpCaseCommand.CommandId, followUpCaseCommand.CaseId, followUpCaseCommand.Description, followUpCaseCommand.DateOfMostRecentInformation);
        }

        #endregion ICommandHandler
    }
}
