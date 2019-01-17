using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.CommandHandlers
{
    public class ImportCaseCommandHandler : ICommandHandler<ImportCaseCommand>
    {
        #region Setup
        private readonly ICaseService caseService;

        public ImportCaseCommandHandler(ICaseService caseService)
        {
            this.caseService = caseService;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(ImportCaseCommand importCaseCommand)
        {
            var newCase = new Case(importCaseCommand.CaseId, importCaseCommand.Description, importCaseCommand.InitialDate);

            caseService.RegisterCase(importCaseCommand.CommandId, newCase);
        }

        #endregion ICommandHandler
    }
}
