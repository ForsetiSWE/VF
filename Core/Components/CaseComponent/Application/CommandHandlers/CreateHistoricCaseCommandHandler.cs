using System;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.CommandHandlers
{
    public class CreateHistoricCaseCommandHandler : ICommandHandler<CreateHistoricCaseCommand>
    {
        #region Setup
        private readonly IHistoricCaseService historicCaseService;

        public CreateHistoricCaseCommandHandler(IHistoricCaseService historicCaseService)
        {
            this.historicCaseService = historicCaseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(CreateHistoricCaseCommand createHistoricCaseCommand)
        {

            historicCaseService.CreateHistoricCase(createHistoricCaseCommand.CommandId, Guid.NewGuid(), createHistoricCaseCommand.CaseId, createHistoricCaseCommand.Revision);
        }

        #endregion ICommandHandler
    }
}
