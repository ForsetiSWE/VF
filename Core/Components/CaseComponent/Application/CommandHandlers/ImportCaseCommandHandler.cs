using System;
using System.Linq;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Commands;
using Umc.VigiFlow.Core.Components.CaseComponent.Application.Services;
using Umc.VigiFlow.Core.Components.CaseComponent.Domain.Models;
using Umc.VigiFlow.Core.Ports;
using Umc.VigiFlow.Core.SharedKernel.Commands;

namespace Umc.VigiFlow.Core.Components.CaseComponent.Application.CommandHandlers
{
    public class ImportCaseCommandHandler : ICommandHandler<ImportCaseCommand>
    {
        #region Setup

        private readonly IImportService importService;
        private readonly ICommandBus commandBus;

        public ImportCaseCommandHandler(IImportService importService, ICommandBus commandBus)
        {
            this.importService = importService;
            this.commandBus = commandBus;
        }

        #endregion Setup

        #region ICommandHandler

        public void Handle(ImportCaseCommand importCaseCommand)
        {
            // Create Import
            var newImport = new Import(importCaseCommand.ImportId, importCaseCommand.ImportIdentifier, importCaseCommand.ImportItems.Select(importItem => new ImportItem(importItem.importItemId, importItem.description)).ToList());

            // Create RegisterCaseCommand for each importItem
            newImport.ImportItems.ForEach(importItem =>
            {
                // This probably should set some propterty on ImportItem connecting it to the resulting Case
                commandBus.Send(new RegisterCaseCommand(Guid.NewGuid(), Guid.NewGuid(), importItem.Description, DateTime.Now, importCaseCommand.CommandId));
            });

            // Persist Import
            importService.Import(importCaseCommand.CommandId, newImport);

        }

        #endregion ICommandHandler
    }
}
